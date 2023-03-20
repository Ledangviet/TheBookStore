using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Xml.Linq;

namespace TheBookStore.Data
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser> 
    {
        private readonly DbContextOptions<BookStoreDbContext> context;
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> opt) : base(opt)
        {
            context = opt;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName="Admin"},                  
                    new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName="User"},
                    new IdentityRole() { Name = "Dev", ConcurrencyStamp = "3", NormalizedName = "Dev" }
                );
        }      
        #region Dbset
        public DbSet<Product>? Products { get; set; } 
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? orderDetails { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }
        #endregion
    }
}
