using CircuitCruisers.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace CircuitCruisers.Models.ViewModels
{
    public class UsersViewModel
    {
        public IList<AppUser> Users { get; set; } = new List<AppUser>();
        public IList<AppUser> Administrators { get; set; } = new List<AppUser>();

    }
}
