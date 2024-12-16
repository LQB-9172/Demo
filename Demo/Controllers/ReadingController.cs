using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IReadingRepository _readingRepo;

        public ReadingController(IReadingRepository readingRepo)
        {
            _readingRepo = readingRepo;
        }

        [HttpPost("recognize-microphone")]
        public async Task<IActionResult> RecognizeSpeechFromMicrophone()
        {
            try
            {
                var recognizedText = await _readingRepo.RecognizeSpeechFromMicrophoneAsync();
                return Ok(new { Text = recognizedText });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReadings()
        {
            try
            {
                return Ok(await _readingRepo.GetAllReadingsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReadingById(int id)
        {
            var reading = await _readingRepo.GetReading(id);
            return reading == null ? NotFound() : Ok(reading);
        }

        [HttpPost]
        public async Task<IActionResult> AddReading(ReadingModel model)
        {
            var newReadingID = await _readingRepo.AddReadingAsync(model);
            var reading = await _readingRepo.GetReading(newReadingID);
            return reading == null ? NotFound() : Ok(reading);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReading(int id, ReadingModel model)
        {
            if (id != model.QuestionID)
                return BadRequest("ID mismatch");

            var result = await _readingRepo.UpdateReadingAsync(id, model);
            if (result) return Ok();

            return BadRequest("Reading does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReading(int id)
        {
            var result = await _readingRepo.DeleteReadingAsync(id);
            if (result) return Ok();

            return BadRequest("Reading does not exist");
        }
    }
}
