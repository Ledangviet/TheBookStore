using TheBookStore.Data;
using TheBookStore.Models;

namespace TheBookStore.Repository
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> getAllProductAsync();
        public Task<ProductModel> getProductAsync(int id);
        public Task<int> AddProductAsync(ProductModel model);
        public Task UpdateProductAsync(int id ,ProductModel model);
        public Task DeleteProductAsync(int id);
        public Task<string> UploadImageAsync(IFormFile file, int id);
    }
}
