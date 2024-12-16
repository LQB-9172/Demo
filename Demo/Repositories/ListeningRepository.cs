using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class ListeningRepository : IListeningRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;
        public ListeningRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddQuestionAsync(ListeningModel model)
        {
            var newQuestion = _mapper.Map<Listening>(model);
            _context.Questions.Add(newQuestion);
            await _context.SaveChangesAsync();
            return newQuestion.QuestionID;
        }
        public async Task<bool> CheckAnswerAsync(int questionId, int selectedAnswer)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
                return false;

            return question.CorrectAnswer == selectedAnswer;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var deleteQuestion = await _context.Questions.FindAsync(id);
            if (deleteQuestion == null)
            {
                return false;
            }

            _context.Questions.Remove(deleteQuestion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ListeningModel>> GetAllQuestionAsync()
        {
            var questions = await _context.Questions.ToListAsync();
            return _mapper.Map<List<ListeningModel>>(questions);
        }


        public async Task<ListeningModel> GetQuestion(int QuestionId)
        {
            var question = await _context.Questions.FindAsync(QuestionId);
            return _mapper.Map<ListeningModel>(question);
        }

        public async Task<bool> UpdateQuestionAsync(int id, ListeningModel model)
        {
            var existQuestion = await _context.Questions.FindAsync(id);
            if (existQuestion != null)
            {
                _context.Entry(existQuestion).State = EntityState.Detached;
                var updateQuestion = _mapper.Map<Listening>(model);
                _context.Questions.Update(updateQuestion);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
