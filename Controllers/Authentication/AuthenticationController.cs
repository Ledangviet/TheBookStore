using Microsoft.AspNetCore.Mvc;
using TheBookStore.Data;
using TheBookStore.Models.Authentication;
using TheBookStore.Repository;

namespace TheBookStore.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAccountRepository _accountRepo;
        public AuthenticationController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if(model.Password == model.ConfirmPassword)
            {
                await _accountRepo.SignUpAsync(model);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }

}
