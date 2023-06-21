using CircuitCruisers.Models.Entities;

namespace CircuitCruisers.Models.ViewModels
{
    public class SupportTicketsViewModel
    {
        public string? Title { get; set; }
        public IEnumerable<ContactFormEntity> Tickets { get; set; } = new List<ContactFormEntity>(); 
    }
}
