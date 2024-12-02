using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public StudentRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddStudentAsync(StudentModel model)
        {
            var newStudent = _mapper.Map<Student>(model);
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return newStudent.StudentID; 
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var deleteStudent = await _context.Students.FindAsync(id);
            if (deleteStudent == null)
            {
                return false;
            }

            _context.Students.Remove(deleteStudent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<StudentModel>> GetAllStudentAsync()
        {
            var students = await _context.Students.ToListAsync();
            return _mapper.Map<List<StudentModel>>(students);
        }

        public async Task<StudentModel> GetStudent(int StudentId)
        {
            var student = await _context.Students.FindAsync(StudentId);
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<bool> UpdateStudentAsync(int id, StudentModel model)
        {
            var existStudent = await _context.Students.FindAsync(id);
            if (existStudent != null)
            {
                _context.Entry(existStudent).State = EntityState.Detached;
                var updateStudent = _mapper.Map<Student>(model);
                _context.Students.Update(updateStudent);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<StudentModel> GetByUserIdAsync(string userId)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.UserId == userId);
            return _mapper.Map<StudentModel>(student);
        }
    }
}
