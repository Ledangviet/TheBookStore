using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookStore.Models.Authentication;
using TheBookStore.Repository;

namespace TheBookStore.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAccountRepository _accountRepo;
        public AdminController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "Ahmed", "Ali", "Ahsan" };
        }
    }
}
