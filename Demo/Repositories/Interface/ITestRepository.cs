using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface ITestRepository
    {
        public Task<List<TestModel>> GetAllTestAsync();
        public Task<TestModel> GetTest(int TestId);
        public Task<int> AddTestAsync(TestModel model);
        public Task<bool> UpdateTestAsync(int id, TestModel model);
        public Task<bool> DeleteTestAsync(int id);
    }
}
