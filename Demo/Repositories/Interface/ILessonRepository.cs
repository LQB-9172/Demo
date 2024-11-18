using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface ILessonRepository
    {
        public Task<List<LessonModel>> GetAllLessonAsync();
        public Task<LessonModel> GetLesson(int LessonId);
        public Task<int> AddLessonAsync(LessonModel model);
        public Task<bool> UpdateLessonAsync(int id, LessonModel model);
        public Task<bool> DeleteLessonAsync(int id);
    }
}
