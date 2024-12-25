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
        public async Task<List<ListeningModel>> GetRandomListensAsync(int count)
        {
            var listening = await _context.Questions
                .OrderBy(q => Guid.NewGuid())
                .Take(count)
                .ToListAsync();

            var listeningModels = _mapper.Map<List<ListeningModel>>(listening);

            listeningModels.ForEach(q => q.CorrectAnswer = null);

            return listeningModels;
        }

        public async Task<int> CalculateScoreAsync(List<QuestionAnswerModel> answers)
        {
            int score = 0;

            foreach (var answer in answers)
            {
                var listening = await _context.Questions
                    .FirstOrDefaultAsync(q => q.QuestionID == answer.QuestionId);
                if (listening != null && listening.CorrectAnswer == answer.SelectedAnswer)
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
        public async Task<List<TestResultModel>> GetTestHistoryAsync(int studentId)
        {
            var testResults = await _context.TestResults
                .Where(tr => tr.StudentId == studentId)
                .OrderByDescending(tr => tr.CompletionDate)
                .ToListAsync();

            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            var testHistory = testResults.Select(tr => new TestResultModel
            {
                Score = tr.Score,
                CompletionDate = TimeZoneInfo.ConvertTimeFromUtc(tr.CompletionDate, timeZoneInfo)
                                             .ToString("dd/MM/yyyy HH:mm")
            }).ToList();

            return testHistory;
        }

    }
}

