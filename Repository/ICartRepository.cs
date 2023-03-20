using Microsoft.AspNetCore.SignalR;
using TheBookStore.Data;
using TheBookStore.Models;

namespace TheBookStore.Repository
{
    public interface ICartRepository
    {
        public Task<List<CartModel>> getCartAsync(string userId);
        public Task<List<CartModel>> addToCartAsync(int productid , string userId);
        public Task<bool> deleteFromCartAsync(int productId , string userId);

        public Task<InvoiceModel> exportInvoiceAsync(string userName);
        
    }
}
