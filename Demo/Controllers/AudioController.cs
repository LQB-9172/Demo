using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly IAudioRepository _audioRepo;

        public AudioController(IAudioRepository audioRepo)
        {
            _audioRepo = audioRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAudios()
        {
            try
            {
                return Ok(await _audioRepo.GetAllAudioAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAudioById(int id)
        {
            var audio = await _audioRepo.GetAudio(id);
            return audio == null ? NotFound() : Ok(audio);
        }

        [HttpPost]
        public async Task<IActionResult> AddAudio(AudioModel model)
        {
            var newAudioID = await _audioRepo.AddAudioAsync(model);
            var audio = await _audioRepo.GetAudio(newAudioID);
            return audio == null ? NotFound() : Ok(audio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAudio(int id, AudioModel model)
        {
            if (id != model.AudioId)
                return BadRequest("ID mismatch");
            var result = await _audioRepo.UpdateAudioAsync(id, model);
            if (result) return Ok();
            return BadRequest("Audio does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudio(int id)
        {
            var result = await _audioRepo.DeleteAudioAsync(id);
            if (result) return Ok();
            return BadRequest("Audio does not exist");
        }
    }
}
