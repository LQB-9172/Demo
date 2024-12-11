using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;
using Demo.Repositories;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepo;
        private readonly IProgressRepository _ProgressRepository;

        public LessonController(ILessonRepository lessonRepo, IProgressRepository ProgressRepository)
        {
            _lessonRepo = lessonRepo;
            _ProgressRepository = ProgressRepository;
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

        [HttpGet("{lessonId}")]
        [ActionName("GetLessonById")]
        public async Task<IActionResult> GetLessonDetailsAsync(int lessonId)
        {
            var lessonDetails = await _lessonRepo.GetLessonDetails(lessonId);
            if (lessonDetails == null) return NotFound();

            return Ok(lessonDetails);
        }
        [HttpGet("student/{studentId}/lessons")]
        [ActionName("GetLessonsByStudent")]
        public async Task<IActionResult> GetLessonByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
            {
                return BadRequest("Student ID must be greater than zero.");
            }
            var lessons = await _lessonRepo.GetLessonByStudentIdAsync(studentId);
            return Ok(lessons);
        }
        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonModel model)
        {
            var newLessonID = await _lessonRepo.AddLessonAsync(model);
            var lesson = await _lessonRepo.GetLessonDetails(newLessonID);
            await _ProgressRepository.UpdateProgressForAllStudentsAsync();
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
        [HttpPut("complete/{studentId}/{lessonId}")]
        public async Task<IActionResult> MarkLessonAsCompleted(int studentId, int lessonId)
        {
            if (studentId <= 0 || lessonId <= 0)
                return BadRequest("Invalid student or lesson ID.");

            await _lessonRepo.UpdateLessonCompletionAsync(studentId, lessonId);
            await _ProgressRepository.UpdateProgressAsync(studentId);

            return NoContent();
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result = await _lessonRepo.DeleteLessonAsync(id);
            await _ProgressRepository.UpdateProgressForAllStudentsAsync();
            if (result) return Ok();
            return BadRequest("Lesson does not exist");
        }
    }
}
