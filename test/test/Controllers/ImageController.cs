using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repositories;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepositories _Imagerepo;

        public ImageController(IImageRepositories repo)
        {
            _Imagerepo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageForLesson(int id)
        {
            var image = await _Imagerepo.GetImage(id);
            return image == null ? NotFound() : Ok(image);
        }
    }
}
