using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepo;

        public LessonController(ILessonRepository lessonRepo)
        {
            _lessonRepo = lessonRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            try
            {
                return Ok(await _lessonRepo.GetAllLessonAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var lesson = await _lessonRepo.GetLesson(id);
            return lesson == null ? NotFound() : Ok(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonModel model)
        {
            var newLessonID = await _lessonRepo.AddLessonAsync(model);
            var lesson = await _lessonRepo.GetLesson(newLessonID);
            return lesson == null ? NotFound() : Ok(lesson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonModel model)
        {
            if (id != model.LessonID)
                return BadRequest("ID mismatch");
            var result = await _lessonRepo.UpdateLessonAsync(id, model);
            if (result) return Ok();
            return BadRequest("Lesson does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result = await _lessonRepo.DeleteLessonAsync(id);
            if (result) return Ok();
            return BadRequest("Lesson does not exist");
        }
    }
}
