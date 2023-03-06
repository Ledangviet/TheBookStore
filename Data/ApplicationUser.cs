using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace TheBookStore.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = null;
    }
}
