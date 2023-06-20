using Microsoft.AspNetCore.Identity;

namespace CircuitCruisers.Models.Identity
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
