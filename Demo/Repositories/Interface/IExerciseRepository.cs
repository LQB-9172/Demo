using Demo.Data;
using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface IExerciseRepository
    {
        public Task<List<ExerciseModel>> GetAllExerciseAsync();
        public Task<ExerciseModel> GetExercise(int ExerciseId);
        public Task<int> AddExerciseAsync(ExerciseModel model);
        public Task<bool> UpdateExerciseAsync(int id, ExerciseModel model);
        public Task<bool> DeleteExerciseAsync(int id);
    }
}
