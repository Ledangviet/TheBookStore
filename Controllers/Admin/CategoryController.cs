using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBookStore.Models;
using TheBookStore.Repository;

namespace TheBookStore.Controllers.Admin
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _catRepo;
        public CategoryController(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel model)
        {
            try
            {
                var newCatId = await _catRepo.AddCategoryAsync(model);
                var cat = await _catRepo.getCategoryAsync(newCatId);
                return cat == null ? NotFound() : Ok(cat);
            }
            catch
            {
                return BadRequest();
            }
        }       
        [HttpGet]
        public async Task<IActionResult> getAllCategory()
        {
            try
            {
                return Ok(await _catRepo.getAllCategoryAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCategory(int id)
        {
            var cat = await _catRepo.getCategoryAsync(id);
            if (cat == null) return NotFound();
            await _catRepo.DeleteCategoryAsync(id);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> getCategoryById(int id)
        {
            var cat = await _catRepo.getCategoryAsync(id);
            return cat == null ? NotFound() : Ok(cat);
        }
    }
}
