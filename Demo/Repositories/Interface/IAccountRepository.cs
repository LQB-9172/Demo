using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Identity;

namespace Demo.Repositories.Interface
{
    public interface IAccountRepository
    {
        public Task<TokenModel> SignInAsync(SignInModel model);
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<TokenModel> RefreshTokenAsync(string refreshToken);
        public string GenerateAccessToken(AppUser user);
        public string GenerateRefreshToken();
        public Task SaveRefreshTokenAsync(AppUser user, string refreshToken);
        public Task<RefreshToken> GetRefreshTokenAsync(string token);
        public Task<AppUser> GetUserByRefreshTokenAsync(string refreshToken);

    }
}
