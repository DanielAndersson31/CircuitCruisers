﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CircuitCruisers.Models.Entities
{
    public class ProductReviewEntity
    {
        public int Id { get; set; }
        public DateTime WhenCreated { get; set; } = DateTime.Now;
        public int Rating { get; set; }
        public string? Comment { get; set; }

        [ForeignKey(nameof(Product))]
        public string ArticleNumber { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;
    }

 
}


