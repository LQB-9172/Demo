using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _progressRepo;
        private readonly IStudentRepository _studentRepo;

        public ProgressController(IProgressRepository progressRepo, IStudentRepository studentRepo)
        {
            _progressRepo = progressRepo;
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgress()
        {
            try
            {
                return Ok(await _progressRepo.GetAllProgressAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgressById(int id)
        {
            var progress = await _progressRepo.GetProgress(id);
            return progress == null ? NotFound() : Ok(progress);
        }

        [HttpPost]
        public async Task<IActionResult> AddProgress(ProgressModel model)
        {
            var student = await _studentRepo.GetStudent(model.StudentID);
            if (student == null)
            {
                return BadRequest("Student does not exist");
            }
            var newProgressID = await _progressRepo.AddProgressAsync(model);
            var progress = await _progressRepo.GetProgress(newProgressID);
            return progress == null ? NotFound() : Ok(progress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgress(int id, ProgressModel model)
        {
            if (id != model.ProgressID)
                return BadRequest("ID mismatch");
            var result = await _progressRepo.UpdateProgressAsync(id, model);
            if (result) return Ok();
            return BadRequest("Progress does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgress(int id)
        {
            var result = await _progressRepo.DeleteProgressAsync(id);
            if (result) return Ok();
            return BadRequest("Progress does not exist");
        }
    }
}
