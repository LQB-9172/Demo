using Demo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechController : ControllerBase
    {
        private readonly ISpeechToTextService _speechToTextService;

        public SpeechController(ISpeechToTextService speechToTextService)
        {
            _speechToTextService = speechToTextService;
        }

        [HttpPost("recognize-microphone")]
        public async Task<IActionResult> RecognizeSpeechFromMicrophone()
        {
            try
            {
                var recognizedText = await _speechToTextService.RecognizeSpeechFromMicrophoneAsync();
                return Ok(new { Text = recognizedText });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Error = ex.Message });
            }
        }
    }
}
