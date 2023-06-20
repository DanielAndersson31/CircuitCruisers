using CircuitCruisers.Contexts;
using CircuitCruisers.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CircuitCruisers.Helpers.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(CircuitCruisersDB context) : base(context)
        {
        }
    }
}
