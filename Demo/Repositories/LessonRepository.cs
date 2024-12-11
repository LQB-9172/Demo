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

            var students = await _context.Students.ToListAsync();

            var studentLessons = students.Select(student => new StudentLesson
            {
                StudentID = student.StudentID,
                LessonID = newLesson.LessonID,
                IsCompleted = false
            });

            _context.StudentLessons.AddRange(studentLessons);
            await _context.SaveChangesAsync();
            return newLesson.LessonID;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var studentLessons = _context.StudentLessons.Where(sl => sl.LessonID == id);
            _context.StudentLessons.RemoveRange(studentLessons);

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

        public async Task<LessonDetailsModel> GetLessonDetails(int lessonId)
        {
            var lesson = await _context.Lessons
                .Include(l => l.Images)
                .Include(l => l.Audios)
                .FirstOrDefaultAsync(l => l.LessonID == lessonId);

            if (lesson == null) return null;

            var lessonDetails = new LessonDetailsModel
            {
                LessonID = lesson.LessonID,
                Title = lesson.Title,
                Images = lesson.Images.Select(i => new ImageModel
                {
                    ImageId = i.ImageId,
                    ImageUrl = i.ImageUrl,
                    Description = i.Description
                }).ToList(),
                Videos = lesson.Audios.Select(a => new VideoModel
                {
                    VideoId = a.VideoId,
                    VideoUrl = a.VideoUrl,
                    Description = a.Description
                }).ToList()
            };

            return lessonDetails;
        }

        public async Task<List<StudentLessonModel>> GetLessonByStudentIdAsync(int studentId)
        {
            var studentLessons = await _context.StudentLessons
                    .Include(sl => sl.Lesson)
                    .Where(sl => sl.StudentID == studentId)
                    .ToListAsync();

            return _mapper.Map<List<StudentLessonModel>>(studentLessons);
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

        public async Task UpdateLessonCompletionAsync(int studentId, int lessonId)
        {
            var studentLesson = await _context.StudentLessons
                .FirstOrDefaultAsync(sl => sl.StudentID == studentId && sl.LessonID == lessonId);
            if (studentLesson == null)
                throw new KeyNotFoundException("StudentLesson not found.");

            studentLesson.IsCompleted = true;
            studentLesson.CompletedDate = DateTime.UtcNow;

            _context.StudentLessons.Update(studentLesson);
            await _context.SaveChangesAsync();
        }
    }
}
