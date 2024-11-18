using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories.Interface;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepo;

        public ImageController(IImageRepository imageRepo)
        {
            _imageRepo = imageRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            try
            {
                return Ok(await _imageRepo.GetAllImageAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _imageRepo.GetImage(id);
            return image == null ? NotFound() : Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(ImageModel model)
        {
            var newImageID = await _imageRepo.AddImageAsync(model);
            var image = await _imageRepo.GetImage(newImageID);
            return image == null ? NotFound() : Ok(image);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(int id, ImageModel model)
        {
            if (id != model.ImageId)
                return BadRequest("ID mismatch");
            var result = await _imageRepo.UpdateImageAsync(id, model);
            if (result) return Ok();
            return BadRequest("Image does not exist");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var result = await _imageRepo.DeleteImageAsync(id);
            if (result) return Ok();
            return BadRequest("Image does not exist");
        }
    }
}
