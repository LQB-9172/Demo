using AutoMapper;
using Demo.Data;
using Demo.Helpers;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public ProgressRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task UpdateProgressAsync(int studentId)
        {
            var lessons = await _context.StudentLessons
                .Where(sl => sl.StudentID == studentId)
                .ToListAsync();
            double completionPercentage = ProgressHelper.CalculateCompletionPercentage(lessons);

            var progress = await _context.Progresses
                .FirstOrDefaultAsync(p => p.StudentID == studentId);

            if (progress != null)
            {
                progress.CompletionPercentage = completionPercentage;
            }
            else
            {
                _context.Progresses.Add(new Progress
                {
                    StudentID = studentId,
                    CompletionPercentage = completionPercentage
                });
            }
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProgressForAllStudentsAsync()
        {

            var students = await _context.Students.ToListAsync();
            foreach (var student in students)
            {
                await UpdateProgressAsync(student.StudentID);
            }
        }


    }
}
