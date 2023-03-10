using Microsoft.Build.Framework;

namespace TheBookStore.Data
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public IFormFile file { get; set; }

    }
}
