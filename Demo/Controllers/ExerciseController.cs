using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepo;
        private readonly ILessonRepository _lessonRepo;

        public ExerciseController(IExerciseRepository exerciseRepo, ILessonRepository lessonRepo)
        {
            _exerciseRepo = exerciseRepo;
            _lessonRepo = lessonRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            try
            {
                return Ok(await _exerciseRepo.GetAllExerciseAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            var exercise = await _exerciseRepo.GetExercise(id);
            return exercise == null ? NotFound() : Ok(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(ExerciseModel model)
        {
            var lesson = await _lessonRepo.GetLesson(model.LessonID);
            if (lesson == null)
            {
                return BadRequest("Lesson ID does not exist");
            }

            var newExerciseID = await _exerciseRepo.AddExerciseAsync(model);
            var exercise = await _exerciseRepo.GetExercise(newExerciseID);
            return exercise == null ? NotFound() : Ok(exercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id, ExerciseModel model)
        {
            if (id != model.ExerciseID)
                return BadRequest("ID mismatch");
            var result = await _exerciseRepo.UpdateExerciseAsync(id, model);
            if (result) return Ok();
            return BadRequest("Exercise does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var result = await _exerciseRepo.DeleteExerciseAsync(id);
            if (result) return Ok();
            return BadRequest("Exercise does not exist");
        }
    }
}
