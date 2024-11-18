using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using test.Data;
using test.Models;

namespace test.Repositories
{
    public class LessonRepositories : ILessonRepositories
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public LessonRepositories(Datacontext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddLessonAsync(LessonModel model)
        {
            var newlesson = _mapper.Map<Lesson>(model);
            _context.Lessons.Add(newlesson);
            await _context.SaveChangesAsync();
            return newlesson.LessonID;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var deleteLesson = _context.Lessons.SingleOrDefault(x=>x.LessonID == id);
            if (deleteLesson != null)
            {
                _context.Lessons.Remove(deleteLesson);
               await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<LessonModel>> GetAllLessonsAsync()
        {
            var Lessons = await _context.Lessons.ToListAsync();
            return _mapper.Map<List<LessonModel>>(Lessons);
        }

        public async Task<LessonModel> GetLessonsByIdAsync(int id)
        {
            var Lesson = await _context.Lessons.FindAsync(id);
            return _mapper.Map<LessonModel>(Lesson);
        }

        public async Task<bool>  UpdateLessonAsync(int id, LessonModel model)
        {
            var existLesson = await _context.Lessons.FindAsync(id);
            if (existLesson!=null)
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
