using CircuitCruisers.Contexts;
using CircuitCruisers.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CircuitCruisers.Helpers.Repositories
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(CircuitCruisersDB context) : base(context)
        {
        }
    }
}
