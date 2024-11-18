using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;
using test.Repositories;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepositories _lessonrepo;

        public LessonController(ILessonRepositories repo)
        {
            _lessonrepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            try
            {
                return Ok(await _lessonrepo.GetAllLessonsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var lesson = await _lessonrepo.GetLessonsByIdAsync(id);
            return lesson == null ? NotFound() : Ok(lesson);

        }
        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonModel model)
        {
            var newLessonID = await _lessonrepo.AddLessonAsync(model);
            var lesson = await _lessonrepo.GetLessonsByIdAsync(newLessonID);
            return lesson == null ? NotFound() : Ok(lesson);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonModel model)
        {
            if (id != model.lessonID)
                return BadRequest("ID mismatch");
            var result = await _lessonrepo.UpdateLessonAsync(id, model);
             if(result == true) return Ok();
                return BadRequest("Lesson not exist");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result = await _lessonrepo.DeleteLessonAsync(id);
            if (result==true) return Ok();
            return BadRequest("Lesson not exist");
        }
    }
}
