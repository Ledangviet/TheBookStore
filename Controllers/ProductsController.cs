using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TheBookStore.Models;
using TheBookStore.Repository;

namespace TheBookStore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepo;

        public ProductsController(IProductRepository repo)
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
        public async Task<IActionResult> AddNewProduct([FromForm] string datajson ,[FromForm] IFormFile file)
        {
            var model = JsonConvert.DeserializeObject<ProductModel>(datajson);
            try
            {

                var newProductId = await _productRepo.AddProductAsync(model);
                var url = await _productRepo.UploadImageAsync(file, newProductId);
                var product = await _productRepo.getProductAsync(newProductId);
                product.ImageUrl = url;
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
