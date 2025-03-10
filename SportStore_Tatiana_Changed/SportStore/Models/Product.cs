﻿using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a product description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a product price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a product category")]
        public string Category { get; set; }

    }
}
