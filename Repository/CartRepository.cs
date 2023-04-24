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
            //list and return all cart
            var listCart = await _context.Carts!.Where(cart => cart.ApplicationUserId == userId).ToListAsync();
            return _mapper.Map<List<CartModel>>(listCart);
        }
        //this will add 1 product to user's cart
        public async Task<List<CartModel>> addToCartAsync(int productid, string userId)
        {
            //find product?
            var product = await _context.Products!.FirstOrDefaultAsync(pr => pr.Id == productid);
            if (product == null)
            {
                return null;
            }
            //find user's cart of this product
            var cart = await _context.Carts!.FirstOrDefaultAsync(c => c.ApplicationUserId == userId && c.ProductId == productid);
            if (cart == null)
            {
                //generate new cart and add to DB
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
                //if cart already exist then plus 1
                cart.Quantity += 1;
                _context.Carts!.Update(cart);
                _context.SaveChanges();
                return await getCartAsync(userId);
            }


        }

        //this will remove 1 product from the cart
        public async Task<bool> deleteFromCartAsync(int productid, string userId)
        {
            //Find Product
            var product = await _context.Products!.FirstOrDefaultAsync(pr => pr.Id == productid);
            if (product == null)
            {
                return false;
            }
            //Find all user's cart
            var cart = await _context.Carts!.FirstOrDefaultAsync(c => c.ApplicationUserId == userId && c.ProductId == productid);
            if (cart == null)
                return false;
            if (cart.Quantity == 1)
            {
                //if quantity = 1 then remove it
                _context.Carts!.Remove(cart);
                _context.SaveChanges();
                return true;
            }
            //if it above 1 then remove 1 product
            cart.Quantity -= 1;
            _context.Carts!.Update(cart);
            _context.SaveChanges();
            return true;
        }
        //This will remove all of product of this User
        public async Task<bool> deleteProductFromCartAsync(int productid, string userId)
        {
            var product = await _context.Products!.FirstOrDefaultAsync(pr => pr.Id == productid);
            if (product == null)
            {
                return false;
            }
            //Find user's product cart and remove all
            var cart = await _context.Carts!.FirstOrDefaultAsync(c => c.ApplicationUserId == userId && c.ProductId == productid);
            _context.Carts!.Remove(cart);
            _context.SaveChanges();
            return true;
        }

        public async Task<InvoiceModel> exportInvoiceAsync(string userName)
        {
            //get user
            ApplicationUser user = await accountRepo.GetUserAsync(userName);
            var listCartModel = await getCartAsync(user.Id);
            double totalPrice = 0;

            //account total price
            foreach (var item in listCartModel)
            {
                totalPrice += item.ProductPrice*item.Quantity;
            }
            //export order 
            var order = new Order();            
            order.UserName = user.Name;
            order.ApplicationUserId = user.Id;
            order.TotalPrice = totalPrice;
            order.CreatedDate = DateTime.Now;

            _context.Orders!.Add(order);
            _context.SaveChanges();

            //export order detail
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
                await deleteProductFromCartAsync(item.ProductId, user.Id);               
            }
            _context.SaveChanges();

            var invoiceModel = new InvoiceModel();
            invoiceModel.UserId = user.Id;
            invoiceModel.UserName = user.Name;
            invoiceModel.TotalPrice = totalPrice;
            invoiceModel.Cart = listCartModel;
            return invoiceModel;
        }

        public async Task<List<Order>> getListOrder(string userName)
        {

            ApplicationUser user = await accountRepo.GetUserAsync(userName);
            var ListOrder = _context.Orders!.Where(e => e.ApplicationUserId == user.Id).ToList();    
            return ListOrder;
        }
    }
}
