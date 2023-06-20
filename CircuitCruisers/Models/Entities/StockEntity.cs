using System.ComponentModel.DataAnnotations;

namespace CircuitCruisers.Models.Entities
{
    public class StockEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string DefaultCurrency { get; set; } = null!;


        public ProductEntity Product { get; set; } = null!;

    }
 
}


