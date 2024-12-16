using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Demo.Repositories.Interface;

namespace Demo.Repositories
{
    public class SpeechToTextService : ISpeechToTextService
    {
        private readonly string _apiKey;
        private readonly string _region;

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
        public SpeechToTextService(string apiKey, string region)
        {
            _apiKey = apiKey;
            _region = region;
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
    }
}
