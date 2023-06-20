
using CircuitCruisers.Models.Dtos;

namespace CircuitCruisers.Models.ViewModels
{
    public class CollectionViewModel
    {
        public string? UserInput { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Product> Items { get; set; } = new List<Product>();
    }
}
