using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface IProgressRepository
    {
        public Task<List<ProgressModel>> GetAllProgressAsync();
        public Task<ProgressModel> GetProgress(int ProgressId);
        public Task<int> AddProgressAsync(ProgressModel model);
        public Task<bool> UpdateProgressAsync(int id, ProgressModel model);
        public Task<bool> DeleteProgressAsync(int id);
    }
}
