using Demo.Data;
using Demo.Helpers;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Demo.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Datacontext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Interface.IEmailSender _emailSender;

        public AccountRepository(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager,
            Datacontext context,
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory,
            Interface.IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _emailSender = emailSender;
        }
        public string GenerateAccessToken(AppUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = _userManager.GetRolesAsync(user).Result;
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
        public async Task SaveRefreshTokenAsync(AppUser user, string refreshToken)
        {
            var existingToken = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.UserId == user.Id);

            if (existingToken != null)
            {
                existingToken.Token = refreshToken;
                existingToken.ExpiryDate = DateTime.Now.AddDays(7);
                _context.RefreshTokens.Update(existingToken);
            }
            else
            {
                var newToken = new RefreshToken
                {
                    Token = refreshToken,
                    UserId = user.Id,
                    ExpiryDate = DateTime.Now.AddDays(7)
                };
                await _context.RefreshTokens.AddAsync(newToken);
            }

            await _context.SaveChangesAsync();
        }
        public async Task<RefreshToken> GetRefreshTokenAsync(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == token);
        }
        public async Task<AppUser> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var token = await GetRefreshTokenAsync(refreshToken);
            if (token == null || token.ExpiryDate <= DateTime.Now)
            {
                return null; 
            }

            return await _userManager.FindByIdAsync(token.UserId);
        }

        public async Task<TokenModel> SignInAsync(SignInModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return null;
            }

            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            await SaveRefreshTokenAsync(user, refreshToken);

            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(AppRole.Account))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Account));
                }

                await _userManager.AddToRoleAsync(user, AppRole.Account);

                var student = new Student
                {
                    UserId = user.Id,
                };

                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                var lessons = await _context.Lessons.ToListAsync();

                var studentLessons = lessons.Select(lesson => new StudentLesson
                {
                    StudentID = student.StudentID,
                    LessonID = lesson.LessonID,
                    IsCompleted = false
                });

                _context.StudentLessons.AddRange(studentLessons);
                await _context.SaveChangesAsync();
            }

            return result;
        }
        public async Task<TokenModel> RefreshTokenAsync(string refreshToken)
        {
            var user = await GetUserByRefreshTokenAsync(refreshToken);
            if (user == null)
            {
                return null;
            }

            var newAccessToken = GenerateAccessToken(user);
            var newRefreshToken = GenerateRefreshToken();

            await SaveRefreshTokenAsync(user, newRefreshToken);

            return new TokenModel
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
        public async Task<AppUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(AppUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }
        public async Task<bool> DeleteUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var userId = user.Id;
                    var userRoles = _context.UserRoles.Where(ur => ur.UserId == userId);
                    _context.UserRoles.RemoveRange(userRoles);
                    var userClaims = _context.UserClaims.Where(uc => uc.UserId == userId);
                    _context.UserClaims.RemoveRange(userClaims);
                    var userLogins = _context.UserLogins.Where(ul => ul.UserId == userId);
                    _context.UserLogins.RemoveRange(userLogins);
                    var userTokens = _context.UserTokens.Where(ut => ut.UserId == userId);
                    _context.UserTokens.RemoveRange(userTokens);
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

    }
}

