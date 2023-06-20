using CircuitCruisers.Contexts;
using CircuitCruisers.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CircuitCruisers.Helpers.Repositories
{
    public class ProductEntityRepository : Repository<ProductEntity>
    {
        private readonly CircuitCruisersDB _context;

        public ProductEntityRepository(CircuitCruisersDB context): base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var items = await _context.Products
                .Include(x => x.Tags).ThenInclude(x => x.Tag)
                .ToListAsync();

            return items;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var items = await _context.Products
                .Include(x => x.Tags).ThenInclude(x => x.Tag)
                .Where(expression)
                .ToListAsync();

            return items;
        }

        //public async Task<IEnumerable<ProductEntity>> GetAllByTagNameAsync(string tagName)
        //{
        //    var items = await _context.Products
        //        .Include(x => x.Tags)
        //        .ThenInclude(x => x.Tag)
        //        .ToListAsync();

        //    foreach (var item in items)
        //    {
               
        //    }

        //    return items;
        //}

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var item = await _context.Products
                  .Include(x => x.Tags).ThenInclude(x => x.Tag)
                  .FirstOrDefaultAsync(expression);

            return item!;
        }
    }
}
