using CircuitCruisers.Contexts;
using CircuitCruisers.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CircuitCruisers.Helpers.Repositories
{
    public class ContactFormRepository : Repository<ContactFormEntity>
    {
        public ContactFormRepository(CircuitCruisersDB context) : base(context)
        {
        }
    }
}
