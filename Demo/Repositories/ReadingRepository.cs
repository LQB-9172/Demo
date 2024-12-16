using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Demo.Repositories.Interface;
using Demo.Data;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Demo.Repositories
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly string _apiKey;
        private readonly string _region;
        private readonly Datacontext _context;
        private readonly IMapper _mapper;
        private readonly Dictionary<string, string> _corrections = new()
    {
        { "Chữ a.", "Chữ a" },
        { "Chữ á.", "Chữ ă" },
        { "Chữ ớ.", "chữ â" },
        { "chữ bờ.", "chữ b" },
        { "Chữ cờ.", "Chữ c" },
        { "Chữ giờ.", "Chữ d" },
        { "Chữ đờ.", "Chữ đ" },
        { "Chữ s.", "Chữ e" },
        { "Chữ ê.", "Chữ ê" },
        { "Chữ g.", "Chữ g" },
        { "Chữ h.", "Chữ h" },
        { "Chữ i.", "Chữ i" },
        { "Chữ k.", "Chữ k" },
        { "Chữ l.", "Chữ l" },
        { "Chữ mờ.", "Chữ m" },
        { "Chữ n.", "Chữ n" },
        { "Chữ o.", "Chữ o" },
        { "Chữ ô.", "Chữ ô" },
        { "Chữ ơ.", "Chữ ơ" },
        { "Chữ b.", "Chữ p" },
        { "Chữ q.", "Chữ q" },//quy
        { "Chữ rr.", "Chữ r" },
        { "Chữ sờ.", "Chữ s" },
        { "Chữ t.", "Chữ t" },
        { "Chữ u.", "Chữ u" },
        { "Chữ ư?", "Chữ ư" },
        { "Chữ vờ.", "Chữ v" },// khó
        { "Chữ xờ.", "Chữ x" },// khó
        { "Chữ y.", "Chữ y" },
        { "Số không?", "Số 0" },
        { "Số một.", "Số 1" },
        { "Số 2.", "Số 2" },
        { "Số 3.", "Số 3" },
        { "Số 4.", "Số 4" },
        { "Số 5.", "Số 5" },
        { "Số 6.", "Số 6" },
        { "Số 7.", "Số 7" },
        { "Số 8.", "Số 8" },
        { "Số 9.", "Số 9" }
    };
        public ReadingRepository(string apiKey, string region, Datacontext context, IMapper mapper)
        {
            _apiKey = apiKey;
            _region = region;
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> RecognizeSpeechFromMicrophoneAsync()
        {
            var speechConfig = SpeechConfig.FromSubscription(_apiKey, _region);
            speechConfig.SpeechRecognitionLanguage = "vi-VN";

            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recognizer.RecognizeOnceAsync();

            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                return ApplyCorrections(result.Text, _corrections);
            }
            else if (result.Reason == ResultReason.NoMatch)
            {
                return "No speech recognized.";
            }
            else
            {
                var cancellation = CancellationDetails.FromResult(result);
                throw new Exception($"Recognition canceled: {cancellation.Reason}, {cancellation.ErrorDetails}");
            }
        }
        public string ApplyCorrections(string input, Dictionary<string, string> corrections)
        {
            foreach (var correction in corrections)
            {
                input = input.Replace(correction.Key, correction.Value, StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
        public async Task<int> AddReadingAsync(ReadingModel model)
        {
            var newReading = _mapper.Map<Reading>(model);
            _context.Readings.Add(newReading);
            await _context.SaveChangesAsync();
            return newReading.QuestionID;
        }

        public async Task<bool> DeleteReadingAsync(int id)
        {
            var deleteReading = await _context.Readings.FindAsync(id);
            if (deleteReading == null)
            {
                return false;
            }

            _context.Readings.Remove(deleteReading);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ReadingModel>> GetAllReadingsAsync()
        {
            var readings = await _context.Readings.ToListAsync();
            return _mapper.Map<List<ReadingModel>>(readings);
        }

        public async Task<ReadingModel> GetReading(int readingId)
        {
            var reading = await _context.Readings.FindAsync(readingId);
            return _mapper.Map<ReadingModel>(reading);
        }

        public async Task<bool> UpdateReadingAsync(int id, ReadingModel model)
        {
            var existReading = await _context.Readings.FindAsync(id);
            if (existReading != null)
            {
                _context.Entry(existReading).State = EntityState.Detached;
                var updateReading = _mapper.Map<Reading>(model);
                _context.Readings.Update(updateReading);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

