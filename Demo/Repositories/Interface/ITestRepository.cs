using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface ITestRepository
    {
        public Task<List<QuestionModel>> GetRandomQuestionsAsync(int count);
        public  Task<int> CalculateScoreAsync(List<QuestionAnswerModel> answers);
        public Task<int> SaveTestResultAsync(int studentId, int totalQuestions, int correctAnswers, double score);
        public  Task<List<TestResultModel>> GetTestHistoryAsync(int studentId);

    }
}
