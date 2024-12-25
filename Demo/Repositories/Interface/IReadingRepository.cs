using Demo.Data;
using Demo.Models;
using System.Threading.Tasks;

namespace Demo.Repositories.Interface
{
    public interface IReadingRepository
    {
        public Task<string> RecognizeSpeechFromMicrophoneAsync();
        string ApplyCorrections(string input, Dictionary<string, string> corrections);
        public Task<int> AddReadingAsync(ReadingModel model);
        public  Task<bool> DeleteReadingAsync(int id);
        public  Task<List<ReadingModel>> GetAllReadingsAsync();
        public  Task<ReadingModel> GetReading(int readingId);
        public  Task<bool> UpdateReadingAsync(int id, ReadingModel model);
    }
}
