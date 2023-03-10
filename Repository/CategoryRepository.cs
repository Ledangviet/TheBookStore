using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheBookStore.Data;
using TheBookStore.Models;

namespace TheBookStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryModel model)
        {

            var newCat = _mapper.Map<Category>(model);
            _context.Categories!.Add(newCat);
            await _context.SaveChangesAsync();
            return newCat.Id;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var deleteCat = _context.Categories!.FirstOrDefault(p => p.Id == id);
            if (deleteCat != null)
            {
                _context.Categories!.Remove(deleteCat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryModel>> getAllCategoryAsync()
        {
            var cats = await _context.Categories!.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(cats);
        }

        public async Task<CategoryModel> getCategoryAsync(int id)
        {
            var cat = await _context.Categories!.FindAsync(id);
            return _mapper.Map<CategoryModel>(cat);
        }
    }
}
