using Microsoft.AspNetCore.Identity;
using TheBookStore.Models.Authentication;

namespace TheBookStore.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model , string role);
        public Task<string> SignInAsync(SignInModel model);
    }
}
