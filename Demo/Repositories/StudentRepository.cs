using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
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

        //public async Task<int> AddStudentAsync(StudentModel model)
        //{
        //    var newStudent = _mapper.Map<Student>(model);
        //    _context.Students.Add(newStudent);
        //    await _context.SaveChangesAsync();
        //    return newStudent.StudentID; 
        //}

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
            var students = await _context.Students
       .Include(s => s.User)
       .Include(s => s.Progress).ToListAsync();
            return _mapper.Map<List<StudentModel>>(students);
        }

        public async Task<StudentModel> GetStudent(int StudentId)
        {
            var student = await _context.Students
        .Include(s => s.User)
        .Include(s => s.Progress)
        .FirstOrDefaultAsync(s => s.StudentID == StudentId);
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<bool> UpdateStudentAsync(int id, StudentUpdateModel model)
        {
            var student = await _context.Students.Include(s => s.User).FirstOrDefaultAsync(s => s.StudentID == id);

            if (student == null)
                return false;

            // Cập nhật FirstName nếu không rỗng
            if (!string.IsNullOrEmpty(model.FirstName))
                student.User.FirstName = model.FirstName;

            // Cập nhật LastName nếu không rỗng
            if (!string.IsNullOrEmpty(model.LastName))
                student.User.LastName = model.LastName;

            // Cập nhật ImageUrl nếu không rỗng
            if (!string.IsNullOrEmpty(model.ImageUrl))
                student.ImageUrl = model.ImageUrl;

            // Cập nhật Password nếu không rỗng và khớp với ConfirmPassword
            if (!string.IsNullOrEmpty(model.Password) && model.Password == model.ConfirmPassword)
            {
                // Hash mật khẩu trước khi lưu
                var passwordHasher = new PasswordHasher<AppUser>();
                student.User.PasswordHash = passwordHasher.HashPassword(student.User, model.Password);
            }

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<StudentModel> GetByUserIdAsync(string userId)
        {
            var student = await _context.Students
        .Include(s => s.User)
        .Include(s => s.Progress)
        .SingleOrDefaultAsync(s => s.UserId == userId);
            return _mapper.Map<StudentModel>(student);
        }
    }
}
