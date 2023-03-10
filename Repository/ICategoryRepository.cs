using TheBookStore.Models;

namespace TheBookStore.Repository
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryModel>> getAllCategoryAsync();
        public Task<CategoryModel> getCategoryAsync(int id);
        public Task<int> AddCategoryAsync(CategoryModel model);
        public Task DeleteCategoryAsync(int id);
    }
}
