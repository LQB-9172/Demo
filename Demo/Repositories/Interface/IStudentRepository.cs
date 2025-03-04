﻿using Demo.Data;
using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface IStudentRepository
    {
        public Task<List<StudentModel>> GetAllStudentAsync();
        public Task<StudentModel> GetStudent(int StudentId);
        //public Task<int> AddStudentAsync(StudentModel model);
        public Task<bool> UpdateStudentAsync(int id, StudentUpdateModel model);
        public Task<StudentModel> GetByUserIdAsync(string userId);
    }
}
