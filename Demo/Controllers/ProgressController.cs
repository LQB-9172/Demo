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

    }
}
