using test.Models;

namespace test.Repositories
{
    public interface IImageRepositories
    {
        //public Task<List<LessonModel>> GetAllLessonsAsync();
        public Task<ImageModel> GetImage(int lessonId);
        //public Task<int> AddLessonAsync(LessonModel model);
       // public Task<bool> UpdateLessonAsync(int id, LessonModel model);
        //public Task<bool> DeleteLessonAsync(int id);
    }
}
