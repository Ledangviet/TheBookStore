

namespace TheBookStore.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ApplicationUserId { get; set; }
        public double ProductPrice { get; set; }
    }
}
