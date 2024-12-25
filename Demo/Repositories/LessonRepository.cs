using AutoMapper;
using Demo.Data;
using Demo.Helpers;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;
        private readonly AzureBlobService _blobService;

        public LessonRepository(Datacontext context, IMapper mapper, AzureBlobService blobService)
        {
            _context = context;
            _mapper = mapper;
            _blobService = blobService;
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
                .Include(l => l.Videos)
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
                    AudioUrl = i.AudioUrl,
                    Description = i.Description
                }).ToList(),
                Videos = lesson.Videos.Select(a => new VideoModel
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
        public async Task<int> CreateLessonWithFilesAsync(LessonDetailsModel request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var lesson = _mapper.Map<Lesson>(request);

            var existingLesson = await _context.Lessons
                .Include(l => l.Images)
                .Include(l => l.Videos)
                .FirstOrDefaultAsync(l => l.LessonID == lesson.LessonID);

            if (existingLesson != null)
                throw new InvalidOperationException("Lesson đã tồn tại trong hệ thống.");
            _context.Lessons.Add(lesson);

            await _context.SaveChangesAsync();
            var students = await _context.Students.ToListAsync();

            var studentLessons = students.Select(student => new StudentLesson
            {
                StudentID = student.StudentID,
                LessonID = lesson.LessonID,
                IsCompleted = false
            });
            _context.StudentLessons.AddRange(studentLessons);
            await _context.SaveChangesAsync();
            return lesson.LessonID;
        }
    }
}
