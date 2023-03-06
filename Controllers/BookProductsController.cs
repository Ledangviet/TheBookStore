using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBookStore.Models;
using TheBookStore.Repository;

namespace TheBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookProductsController : ControllerBase
    {
        private IProductRepository _productRepo;

        public BookProductsController(IProductRepository repo)
        {
            _productRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok( await _productRepo.getAllProductAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getProductById(int id)
        {
            var product = await _productRepo.getProductAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel model)
        {
            try
            {
                var newProductId = await _productRepo.AddProductAsync(model);
                var product = await _productRepo.getProductAsync(newProductId);
                    return product == null ? NotFound() : Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductById(int id,ProductModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _productRepo.UpdateProductAsync(id, model);
            return Ok();
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.getProductAsync(id);
            if( product == null) return NotFound();
            await _productRepo.DeleteProductAsync(id);
            return Ok();
        }
    }
}
