using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
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
            //string connectionString = "DefaultEndpointsProtocol=https;AccountName=bookstoreimg;AccountKey=WNmrBAVUMgIZ0+gNaigHtm3DE5tEHhuy0uTB4Ze+tTndwdoNPBqGZwFU9iq7sq+gnOioXN9F4yXN+ASt/xKCwg==;EndpointSuffix=core.windows.net";

            //BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, "thebookimg");          
            //using(var stream = new MemoryStream())
            //{
            //    await file.CopyToAsync(stream);
            //    stream.Position = 0;
            //    await blobContainerClient.DeleteBlobIfExistsAsync("product_" + product.Id);
            //    await blobContainerClient.UploadBlobAsync("product_" + product.Id, stream);
            //}

            var fileName = Path.GetFileName(file.FileName);

            if (file != null)
            {
                string FileName = "product-" + product.Id + ".png";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Static/Images/", FileName);

                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                string url = "/Static/Images/" + FileName;
                var Image = new ProductImage();
                Image.Title = "product_" + product.Id;
                Image.ProductId = product.Id;
                Image.Url = url;
                _context.ProductImages!.Add(Image);
                product.ImageUrl = url;
                _context.Products!.Update(product);
                _context.SaveChanges();
                return url;
            }
            return null;
        }
    }
}
