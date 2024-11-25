using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;
using Demo.Repositories;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionsController(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }
        public class UserAnswer
        {
            public int QuestionID { get; set; }
            public int SelectedAnswer { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                return Ok(await _questionRepo.GetAllQuestionAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionRepo.GetQuestion(id);
            return question == null ? NotFound() : Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(QuestionModel model)
        {
            var newQuestionID = await _questionRepo.AddQuestionAsync(model);
            var question = await _questionRepo.GetQuestion(newQuestionID);
            return question == null ? NotFound() : Ok(question);
        }
        [HttpPost("check-answer")]
        public async Task<IActionResult> CheckAnswer([FromBody] UserAnswer userAnswer)
        {
            var isCorrect = await _questionRepo.CheckAnswerAsync(userAnswer.QuestionID, userAnswer.SelectedAnswer);

            if (isCorrect)
                return Ok(new { Message = "Đáp án đúng!" });
            else
                return Ok(new { Message = "Đáp án sai." });
        }
    

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, QuestionModel model)
        {
            if (id != model.QuestionID)
                return BadRequest("ID mismatch");
            var result = await _questionRepo.UpdateQuestionAsync(id, model);
            if (result == true) return Ok();
            return BadRequest("Question does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var result = await _questionRepo.DeleteQuestionAsync(id);
            if (result == true) return Ok();
            return BadRequest("Question does not exist");
        }
    }

}
