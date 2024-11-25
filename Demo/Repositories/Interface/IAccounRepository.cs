using Demo.Models;
using Microsoft.AspNetCore.Identity;

namespace Demo.Repositories.Interface
{
    public interface IAccounRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
