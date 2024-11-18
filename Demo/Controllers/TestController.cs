using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepo;

        public TestController(ITestRepository testRepo)
        {
            _testRepo = testRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTests()
        {
            try
            {
                return Ok(await _testRepo.GetAllTestAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestById(int id)
        {
            var test = await _testRepo.GetTest(id);
            return test == null ? NotFound() : Ok(test);
        }

        [HttpPost]
        public async Task<IActionResult> AddTest(TestModel model)
        {
            var newTestID = await _testRepo.AddTestAsync(model);
            var test = await _testRepo.GetTest(newTestID);
            return test == null ? NotFound() : Ok(test);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTest(int id, TestModel model)
        {
            if (id != model.TestID)
                return BadRequest("ID mismatch");
            var result = await _testRepo.UpdateTestAsync(id, model);
            if (result) return Ok();
            return BadRequest("Test does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            var result = await _testRepo.DeleteTestAsync(id);
            if (result) return Ok();
            return BadRequest("Test does not exist");
        }
    }
}
