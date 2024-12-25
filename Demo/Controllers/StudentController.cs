using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                return Ok(await _studentRepo.GetAllStudentAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepo.GetStudent(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserIdAsync(string userId)
        {
            var student = await _studentRepo.GetByUserIdAsync(userId);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateModel model)
        {
            if (id <= 0)
                return BadRequest("Invalid student ID.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _studentRepo.UpdateStudentAsync(id, model);
            if (!result)
                return NotFound("Student not found.");

            return NoContent();
        }
    }
}
