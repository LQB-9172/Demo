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

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentModel model)
        {
            var newStudentID = await _studentRepo.AddStudentAsync(model);
            var student = await _studentRepo.GetStudent(newStudentID);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentModel model)
        {
            if (id != model.StudentID)
                return BadRequest("ID mismatch");
            var result = await _studentRepo.UpdateStudentAsync(id, model);
            if (result) return Ok();
            return BadRequest("Student does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentRepo.DeleteStudentAsync(id);
            if (result) return Ok();
            return BadRequest("Student does not exist");
        }
    }
}
