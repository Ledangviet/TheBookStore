using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBookStore.Data
{
    [Table("Product")]
    public class Product
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range (0, 100)]
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Author { get ; set; } = string.Empty;

        public Boolean IsMeta { get; set; } = false;
    }
}
