﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Policy;
using TheBookStore.Models;
using TheBookStore.Repository;

namespace TheBookStore.Controllers.Admin
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
                return Ok(await _productRepo.getAllProductAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getProductById(int id)
        {
            var product = await _productRepo.getProductAsync(id);           
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewProduct([FromForm] string datajson)
        {
            var model = JsonConvert.DeserializeObject<ProductModel>(datajson);
            try
            {
                var newProductId = await _productRepo.AddProductAsync(model);               
                var product = await _productRepo.getProductAsync(newProductId);
                return product == null ? NotFound() : Ok(product);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> AddProductImage([FromHeader]int id,[FromForm]IFormFile file)
        {
            if(file!= null)
            {
                var product = await _productRepo.getProductAsync(id);
                if(product != null)
                {
                    var url = await _productRepo.UploadImageAsync(file, product);
                    return Ok(url);
                }
                return NotFound("San pham khong ton tai!");         
            }
            return NotFound("File khong ton tai!");
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductById(int id, ProductModel model)
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
            if (product == null) return NotFound();
            await _productRepo.DeleteProductAsync(id);
            return Ok();
        }
    }
}
