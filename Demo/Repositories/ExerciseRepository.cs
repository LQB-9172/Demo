using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public ExerciseRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddExerciseAsync(ExerciseModel model)
        {
            var newExercise = _mapper.Map<Exercise>(model);
            _context.Exercises.Add(newExercise);
            await _context.SaveChangesAsync();
            return newExercise.ExerciseID;
        }

        public async Task<bool> DeleteExerciseAsync(int id)
        {
            var deleteExercise = await _context.Exercises.FindAsync(id);
            if (deleteExercise == null)
            {
                return false;
            }

            _context.Exercises.Remove(deleteExercise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ExerciseModel>> GetAllExerciseAsync()
        {
            var exercises = await _context.Exercises.ToListAsync();
            return _mapper.Map<List<ExerciseModel>>(exercises);
        }

        public async Task<ExerciseModel> GetExercise(int ExerciseId)
        {
            var exercise = await _context.Exercises.FindAsync(ExerciseId);
            return _mapper.Map<ExerciseModel>(exercise);
        }

        public async Task<bool> UpdateExerciseAsync(int id, ExerciseModel model)
        {
            var existExercise = await _context.Exercises.FindAsync(id);
            if (existExercise != null)
            {
                _context.Entry(existExercise).State = EntityState.Detached;
                var updateExercise = _mapper.Map<Exercise>(model);
                _context.Exercises.Update(updateExercise);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
