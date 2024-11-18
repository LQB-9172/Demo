using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public LessonRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddLessonAsync(LessonModel model)
        {
            var newLesson = _mapper.Map<Lesson>(model);
            _context.Lessons.Add(newLesson);
            await _context.SaveChangesAsync();
            return newLesson.LessonID;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var deleteLesson = await _context.Lessons.FindAsync(id);
            if (deleteLesson == null)
            {
                return false;
            }

            _context.Lessons.Remove(deleteLesson);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LessonModel>> GetAllLessonAsync()
        {
            var lessons = await _context.Lessons.ToListAsync();
            return _mapper.Map<List<LessonModel>>(lessons);
        }

        public async Task<LessonModel> GetLesson(int LessonId)
        {
            var lesson = await _context.Lessons.FindAsync(LessonId);
            return _mapper.Map<LessonModel>(lesson);
        }

        public async Task<bool> UpdateLessonAsync(int id, LessonModel model)
        {
            var existLesson = await _context.Lessons.FindAsync(id);
            if (existLesson != null)
            {
                _context.Entry(existLesson).State = EntityState.Detached;
                var updateLesson = _mapper.Map<Lesson>(model);
                _context.Lessons.Update(updateLesson);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
