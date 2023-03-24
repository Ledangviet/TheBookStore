using AutoMapper;
using Azure.Storage.Blobs;
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

        public async Task<string> UploadImageAsync(IFormFile file, ProductModel model)
        {
            var product = _mapper.Map<Product>(model);
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=thebookimage;AccountKey=Hqg/obRKymKZhO3gB0MLGqSxfIV/EkRWLbBXo9bW3145iSaguoqBiXVG7W+agfCAOIJAbxzwIqT6+ASt38jQSg==;EndpointSuffix=core.windows.net";
            string url = "https://thebookimage.blob.core.windows.net/productimg/";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, "productimg");          
            using(var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;
                await blobContainerClient.DeleteBlobIfExistsAsync("product_" + product.Id);
                await blobContainerClient.UploadBlobAsync("product_" + product.Id, stream);
            }
            
            var Image = new ProductImage();
            Image.Title = "product" + product.Id;
            Image.ProductId = product.Id;
            Image.Url = url+ "product" + product.Id;
            _context.ProductImages!.Add(Image);
            product.ImageUrl = url + "product" + product.Id;
            _context.Products!.Update(product);
            _context.SaveChanges();
            return url;
        }
    }
}
