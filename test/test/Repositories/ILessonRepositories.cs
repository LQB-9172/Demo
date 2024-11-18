using test.Data;
using test.Models;

namespace test.Repositories
{
    public interface ILessonRepositories
    {
        public Task<List<LessonModel>> GetAllLessonsAsync();
        public Task<LessonModel> GetLessonsByIdAsync(int id);
        public Task<int> AddLessonAsync(LessonModel model);
        public Task<bool> UpdateLessonAsync(int id, LessonModel model);
        public Task<bool> DeleteLessonAsync(int id);

    }
}
