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
        public string Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range (0, 100)]
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
    }
}
