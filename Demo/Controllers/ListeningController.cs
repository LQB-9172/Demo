using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;
using Demo.Repositories;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListeningController : ControllerBase
    {
        private readonly IListeningRepository _questionRepo;

        public ListeningController(IListeningRepository questionRepo)
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
        public async Task<IActionResult> AddQuestion(ListeningModel model)
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
        public async Task<IActionResult> UpdateQuestion(int id, ListeningModel model)
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
