﻿using Demo.Data;
using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface ILessonRepository
    {
        public Task<List<LessonModel>> GetAllLessonAsync();
        public Task<List<StudentLessonModel>> GetLessonByStudentIdAsync(int studentId);
        public Task<LessonDetailsModel> GetLessonDetails(int LessonId);
        public Task<int> CreateLessonWithFilesAsync(LessonDetailsModel request);
        public Task<bool> UpdateLessonAsync(int id, LessonModel model);
        public Task UpdateLessonCompletionAsync(int studentId, int lessonId);
        public Task<bool> DeleteLessonAsync(int id);
    }
}
