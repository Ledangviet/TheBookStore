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
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
               var result =  await _accountRepo.SignUpAsync(model ,"User");
                if(result == null)
                {
                    return NotFound("Email already Exist!");
                }
                return Ok(result);                
                 
        }
        [Route("seedAdmin")]
        [HttpPost]
        public async Task<IActionResult> SeedAdmin()
        {
            SignUpModel model = new SignUpModel();
            model.Name = "Administrator";
            model.Email = "admin@email.com";
            model.Password = "Admin123#";
            model.ConfirmPassword = "Admin123#";
            var result = await _accountRepo.SignUpAsync(model , "Admin");
            return Ok();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var token = await _accountRepo.SignInAsync(model);
            if (token != null)
            {
                return Ok(token);
            }else return NotFound("Login Fail!");

        }
    }

}
