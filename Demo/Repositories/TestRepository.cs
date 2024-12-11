using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public TestRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<QuestionModel>> GetRandomQuestionsAsync(int count)
        {
            var questions = await _context.Questions
                .OrderBy(q => Guid.NewGuid())
                .Take(count)
                .ToListAsync();

            var questionModels = _mapper.Map<List<QuestionModel>>(questions);

            questionModels.ForEach(q => q.CorrectAnswer = null);

            return questionModels;
        }


        public async Task<int> CalculateScoreAsync(List<QuestionAnswerModel> answers)
        {
            int score = 0;

            foreach (var answer in answers)
            {
                // Lấy câu hỏi từ cơ sở dữ liệu
                var question = await _context.Questions
                    .FirstOrDefaultAsync(q => q.QuestionID == answer.QuestionId);

                // Kiểm tra nếu câu hỏi tồn tại và so sánh câu trả lời học sinh chọn
                if (question != null && question.CorrectAnswer == answer.SelectedAnswer)
                {
                    score++;
                }
            }

            return score;
        }


        public async Task<int> SaveTestResultAsync(int studentId, int totalQuestions, int correctAnswers, double score)
        {
            var testResult = new TestResult
            {
                StudentId = studentId,
                TotalQuestions = totalQuestions,
                CorrectAnswers = correctAnswers,
                Score = score,
                CompletionDate = DateTime.UtcNow
            };

            _context.TestResults.Add(testResult);
            await _context.SaveChangesAsync();

            return testResult.TestResultId;
        }
    }
}

