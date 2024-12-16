using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;
using Demo.Repositories;
using static Demo.Controllers.ListeningController;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepo;
        private readonly IReadingRepository _readingRepo;

        public TestController(ITestRepository testRepo, IReadingRepository readingRepo)
        {
            _testRepo = testRepo;
            _readingRepo = readingRepo;
        }

        [HttpGet("Listen/random")]
        public async Task<IActionResult> GetRandomQuestions(int count = 10)
        {
            var questions = await _testRepo.GetRandomListensAsync(count);

            if (questions == null || !questions.Any())
                return NotFound("No questions available.");

            return Ok(questions);
        }


        [HttpPost("Listen/submit")]
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
        [HttpGet("Listen/history/{studentId}")]
        public async Task<IActionResult> GetTestHistory(int studentId)
        {
            var testHistory = await _testRepo.GetTestHistoryAsync(studentId);

            if (testHistory == null || !testHistory.Any())
            {
                return NotFound("No test history found for the given student.");
            }

            return Ok(testHistory);
        }

        [HttpPost("Reading/{id}")]
        public async Task<IActionResult> Reading(int id)
        {
            var reading = await _readingRepo.GetReading(id);
            if (reading == null)
                return NotFound(new { Message = "Reading không tồn tại." });

            var recognizedText = await _readingRepo.RecognizeSpeechFromMicrophoneAsync();

            if (string.Equals(reading.text, recognizedText, StringComparison.OrdinalIgnoreCase))
            {
                return Ok(new
                {
                    Message = "Đáp án đúng!",
                    RecognizedText = recognizedText
                });
            }
            else
            {
                return Ok(new
                {
                    Message = "Đáp án sai.",
                    RecognizedText = recognizedText
                });
            }
        }


    }
}
