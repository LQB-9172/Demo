using Demo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Repositories.Interface
{
    public interface IListeningRepository
    {
        public Task<List<ListeningModel>> GetAllQuestionAsync();
        public Task<ListeningModel> GetQuestion(int QuestionId);
        public Task<int> AddQuestionAsync(ListeningModel model);
        public Task<bool> UpdateQuestionAsync(int id, ListeningModel model);
        public Task<bool> DeleteQuestionAsync(int id);
        Task<bool> CheckAnswerAsync(int questionId, int selectedAnswer);
    }
}
