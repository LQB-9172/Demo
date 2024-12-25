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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using IEmailSender = Demo.Repositories.Interface.IEmailSender;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accounRepo;
        private readonly IEmailSender _emailSender;

        public AccountsController(IAccountRepository repo, IEmailSender emailSender)
        {
            accounRepo = repo;
            _emailSender = emailSender;
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
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var user = await accounRepo.FindUserByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { Message = "Email không tồn tại trong hệ thống." });
            }

            var token = await accounRepo.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Account", new { token = token, email = user.Email }, Request.Scheme);
            var emailSubject = "Đặt lại mật khẩu của bạn";
            var emailBody = $"Mã đặt lại mật khẩu của bạn là: {token}";

            await _emailSender.SendEmailAsync(user.Email, emailSubject, emailBody);

            return Ok(new { Message = "Mã reset password đã được gửi qua email." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var user = await accounRepo.FindUserByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { Message = "Email không tồn tại trong hệ thống." });
            }

            var result = await accounRepo.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Đặt lại mật khẩu không thành công.", Errors = result.Errors });
            }

            return Ok(new { Message = "Mật khẩu đã được đặt lại thành công." });
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
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteStudent(string email)
        {
            var result = await accounRepo.DeleteUserByEmailAsync(email);
            if (result) return Ok();
            return BadRequest("Student does not exist");
        }

    }

}
