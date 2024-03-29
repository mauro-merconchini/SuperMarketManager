﻿using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double? Price { get; set; }

        // Navigation property for EF core
        public Category? Category { get; set; }
    }
}
