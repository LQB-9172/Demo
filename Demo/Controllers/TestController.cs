using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;
using Demo.Repositories;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepo;

        public TestController(ITestRepository testRepo)
        {
            _testRepo = testRepo;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomQuestions(int count = 10)
        {
            var questions = await _testRepo.GetRandomQuestionsAsync(count);

            if (questions == null || !questions.Any())
                return NotFound("No questions available.");

            return Ok(questions);
        }


        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAnswers([FromBody] SubmitTestModel model)
        {
            // Kiểm tra tính hợp lệ của studentId và answers
            if (model == null || model.StudentId <= 0)
                return BadRequest("Invalid student ID.");

            if (model.Answers == null || !model.Answers.Any())
                return BadRequest("No answers submitted.");

            // Tính điểm từ các câu trả lời
            int score = await _testRepo.CalculateScoreAsync(model.Answers);

            // Lưu kết quả bài kiểm tra vào database
            var resultId = await _testRepo.SaveTestResultAsync(model.StudentId, 10, model.Answers.Count(a => a.SelectedAnswer == a.SelectedAnswer), score);

            return Ok(new
            {
                Score = score,
                TotalQuestions = 10,
                CorrectAnswers = model.Answers.Count(a => a.SelectedAnswer == a.SelectedAnswer),
                TestResultId = resultId
            });
        }
        [HttpGet("history/{studentId}")]
        public async Task<IActionResult> GetTestHistory(int studentId)
        {
            var testHistory = await _testRepo.GetTestHistoryAsync(studentId);

            if (testHistory == null || !testHistory.Any())
            {
                return NotFound("No test history found for the given student.");
            }

            return Ok(testHistory);
        }

    }
}
