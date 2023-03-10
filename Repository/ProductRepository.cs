using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheBookStore.Data;
using TheBookStore.Models;

namespace TheBookStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddProductAsync(ProductModel model)
        {
            var newProduct = _mapper.Map<Product>(model);
            _context.Products!.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteProduct = _context.Products!.FirstOrDefault( p => p.Id == id);
            if (deleteProduct != null)
            {
                _context.Products!.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }  
        }

        public async Task<List<ProductModel>> getAllProductAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> getProductAsync(int id)
        {
            var product = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task UpdateProductAsync(int id,ProductModel model)
        {
            if(id == model.Id)
            {
                var updateProduct = _mapper.Map<Product>(model);
                _context.Products!.Update(updateProduct);
                await _context.SaveChangesAsync();
            }          
        }

        public async Task<string> UploadImageAsync(IFormFile file,int id)
        {
            string url = "";
            if (file != null)
            {
                string FileName = "product-" + id + ".png";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Static/images", FileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                 url = "~/images/detail/" + FileName;
            }
            return url;
        }
    }
}
