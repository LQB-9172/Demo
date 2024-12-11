using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Net.WebRequestMethods;
using Demo.Repositories;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accounRepo;

        public AccountsController(IAccountRepository repo)
        {
            accounRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await accounRepo.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            var errorMessages = result.Errors.Select(e => new { e.Code, e.Description }).ToList();
            return BadRequest(new { errors = errorMessages });
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var tokenModel = await accounRepo.SignInAsync(signInModel);
            if (tokenModel == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(new
            {
                AccessToken = tokenModel.AccessToken,
                RefreshToken = tokenModel.RefreshToken
            });
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var newToken = await accounRepo.RefreshTokenAsync(refreshToken);
            if (newToken == null)
            {
                return Unauthorized(new { message = "Invalid Refresh Token" });
            }

            return Ok(new
            {
                AccessToken = newToken.AccessToken,
                RefreshToken = newToken.RefreshToken
            });
        }
        
    }

}
