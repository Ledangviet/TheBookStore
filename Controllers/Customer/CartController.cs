using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using TheBookStore.Data;
using TheBookStore.Repository;

namespace TheBookStore.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        IProductRepository productRepo;
        ICartRepository cartRepo;
        IAccountRepository accountRepo;
        public CartController(IProductRepository productRepo, ICartRepository cartRepo, IAccountRepository accountRepo)
        {
            this.productRepo = productRepo;
            this.cartRepo = cartRepo;
            this.accountRepo = accountRepo;
        }
        [HttpGet("username")]
        public async Task<IActionResult> getCartAsync([FromHeader]string username)
        {
            ApplicationUser user = await accountRepo.GetUserAsync(username);
            if (user == null)
            {
                return NotFound("Nguoi dung khong ton tai!");
            }
            return Ok(await cartRepo.getCartAsync(user.Id));
        }
        [HttpPost("add/username")]
        public async Task<IActionResult> addToCart([FromHeader]string username , int productId)
        {
            ApplicationUser user = await accountRepo.GetUserAsync(username);
            if (user == null) 
            {
                return NotFound("Nguoi dung khong ton tai!");
            }
             var listCart = await cartRepo.addToCartAsync(productId , user.Id);
            if (listCart == null)
                return NotFound("Het hang!");
            return Ok(listCart);
        }

        [HttpPost("remove/username")]
        public async Task<IActionResult> removeFromCart([FromHeader] string username , int productId)
        {
            ApplicationUser user = await accountRepo.GetUserAsync(username);
            if (user == null)
            {
                return NotFound("Nguoi dung khong ton tai!");
            }
            if(await cartRepo.deleteFromCartAsync(productId , user.Id) == true)
            {
                return Ok(await cartRepo.getCartAsync(user.Id));
            }
            return BadRequest();        
        }
        [HttpPost("Order")]
        public async Task<IActionResult> orderCart([FromHeader] string username)
        {
            ApplicationUser user = await accountRepo.GetUserAsync(username);
            if (user == null)
            {
                return NotFound("Nguoi dung khong ton tai!");
            }
            var invoice = await cartRepo.exportInvoiceAsync(username);
            return Ok(invoice);


        }
    }
}
