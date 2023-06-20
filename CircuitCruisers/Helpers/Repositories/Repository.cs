using CircuitCruisers.Contexts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CircuitCruisers.Helpers.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        #region constructors and private fields

        private readonly CircuitCruisersDB _context;

        protected Repository(CircuitCruisersDB context)
        {
            _context = context;
        }

        #endregion

        

        // Get a specific item
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity!;
        }

        // Get all items
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();  
           
        }

        // Get all items with conditions (Expression)
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
            
        }

        // Add an item to database
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity != null)
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            return null!;
        }

        // Update an item to database
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity != null)
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();  
                return entity;
            }

            return null!;
        }

        // Remove an item from database
        public virtual async Task RemoveAsync(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

        }
               
    }
}
