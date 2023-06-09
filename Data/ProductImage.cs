﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBookStore.Data
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
    }
}
