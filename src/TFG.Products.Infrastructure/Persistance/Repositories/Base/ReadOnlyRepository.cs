using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TFG.Products.Application.Abstractions.Repositories.Base;
using TFG.Products.Domain.Entities;
using TFG.Products.Infrastructure.Persistance.Contexts;

namespace TFG.Products.Infrastructure.Persistance.Repositories.Base
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ProductsDbContext _context;

        public ReadOnlyRepository(ProductsDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, params string[] includeProperties)
        {
            var query = _context.Set<TEntity>()
                        .Where(expression);

            if (includeProperties != null && includeProperties.Any())
                includeProperties.ToList().ForEach(p => query = query.Include(p));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                .ToListAsync();
        }

        public async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>()
                .Where(expression)
                .ToListAsync();
        }
    }
}
