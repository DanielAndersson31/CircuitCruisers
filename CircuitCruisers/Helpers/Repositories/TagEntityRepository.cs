using CircuitCruisers.Contexts;
using CircuitCruisers.Models.Entities;

namespace CircuitCruisers.Helpers.Repositories
{
    public class TagEntityRepository : Repository<TagEntity>
    {
        public TagEntityRepository(CircuitCruisersDB context) : base(context)
        {
        }
    }
}
