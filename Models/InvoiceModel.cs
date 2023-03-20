using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using TheBookStore.Data;

namespace TheBookStore.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string UserName { get; set; }

        public List<CartModel> Cart { get; set; }

        public double TotalPrice { get; set; }

        public DateTime CreatedDate = DateTime.Now;
    }
}
