using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TheBookStore.Data;
using TheBookStore.Models;

namespace TheBookStore.Repository
{
    public class CartRepository : ICartRepository
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        IProductRepository productRepo;
        IAccountRepository accountRepo;
        public CartRepository(BookStoreDbContext context, IMapper mapper ,
            IProductRepository productRepo, IAccountRepository accountRepo)
        {
            _context = context;
            _mapper = mapper;
            this.productRepo = productRepo;
            this.accountRepo = accountRepo;
        }
        public async Task<List<CartModel>> getCartAsync(string userId)
        {
            var listCart = await _context.Carts!.Where(cart => cart.ApplicationUserId == userId).ToListAsync();

            return _mapper.Map<List<CartModel>>(listCart);
        }

        public async Task<List<CartModel>> addToCartAsync(int productid, string userId)
        {
            var product = await _context.Products!.FirstOrDefaultAsync(pr => pr.Id == productid);
            if (product == null)
            {
                return null;
            }
            var cart = await _context.Carts!.FirstOrDefaultAsync(c => c.ApplicationUserId == userId && c.ProductId == productid);
            if (cart == null)
            {
                Cart newcart = new Cart();
                newcart.ProductId = productid;
                newcart.ApplicationUserId = userId;
                newcart.ProductPrice = product.Price;
                newcart.Quantity = 1;
                _context.Carts!.Add(newcart);
                _context.SaveChanges();
                return await getCartAsync(userId);
            }
            else
            {
                cart.Quantity += 1;
                _context.Carts!.Update(cart);
                _context.SaveChanges();
                return await getCartAsync(userId);
            }


        }

        public async Task<bool> deleteFromCartAsync(int productid, string userId)
        {
            //Find Product
            var product = await _context.Products!.FirstOrDefaultAsync(pr => pr.Id == productid);
            if (product == null)
            {
                return false;
            }
            var cart = await _context.Carts!.FirstOrDefaultAsync(c => c.ApplicationUserId == userId && c.ProductId == productid);
            if (cart == null)
                return false;
            if (cart.Quantity == 1)
            {
                _context.Carts!.Remove(cart);
                _context.SaveChanges();
                return true;
            }
            cart.Quantity -= 1;
            _context.Carts!.Update(cart);
            _context.SaveChanges();
            return true;
        }

        public async Task<InvoiceModel> exportInvoiceAsync(string userName)
        {
            ApplicationUser user = await accountRepo.GetUserAsync(userName);
            var listCartModel = await getCartAsync(user.Id);
            double totalPrice = 0;
            foreach (var item in listCartModel)
            {
                totalPrice += item.ProductPrice*item.Quantity;
            }
            var order = new Order();
            order.UserId = user.Id;
            order.UserName = user.Name;
            order.ApplicationUser = user;
            order.TotalPrice = totalPrice;

            _context.Orders!.Add(order);
            _context.SaveChanges();
            var listOrderDetail = new List<OrderDetail>();
            foreach(var item in listCartModel)
            {
                var detail = new OrderDetail();
                detail.ProductId = item.ProductId;
                detail.Quantity = item.Quantity;
                detail.OrderId = order.Id;
                detail.Price = item.ProductPrice;
                _context.orderDetails!.Add(detail);
            }
            _context.SaveChanges();

            //Remove All Cart
            foreach(var item in listCartModel)
            {
                var cart = _context.Carts.Where(e => e.ApplicationUserId == user.Id);
                _context.Remove(cart);
                _context.SaveChanges();
            }
            
            var invoiceModel = new InvoiceModel();
            invoiceModel.UserId = user.Id;
            invoiceModel.UserName = user.Name;
            invoiceModel.TotalPrice = totalPrice;
            invoiceModel.Cart = listCartModel;
            return invoiceModel;
        }
    }
}
