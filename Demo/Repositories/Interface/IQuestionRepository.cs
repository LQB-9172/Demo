using Demo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Repositories.Interface
{
    public interface IQuestionRepository
    {
        public Task<List<QuestionModel>> GetAllQuestionAsync();
        public Task<QuestionModel> GetQuestion(int QuestionId);
        public Task<int> AddQuestionAsync(QuestionModel model);
        public Task<bool> UpdateQuestionAsync(int id, QuestionModel model);
        public Task<bool> DeleteQuestionAsync(int id);
        Task<bool> CheckAnswerAsync(int questionId, int selectedAnswer);
    }
}
