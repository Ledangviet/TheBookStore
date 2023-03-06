using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TheBookStore.Data
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser> 
    { 
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> opt): base(opt)
        {

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
                    new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName="User"}
                );
                
        }

        #region Dbset
        public DbSet<Product>? Products { get; set; }         
        #endregion
    }
}
