using TFG.Products.Application.Abstractions.Repositories.Base;
using TFG.Products.Domain.Entities;
using TFG.Products.Infrastructure.Persistance.Contexts;

namespace TFG.Products.Infrastructure.Persistance.Repositories.Base
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ProductsDbContext _context;

        public Repository(ProductsDbContext context) : base(context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll;
        }

        public async Task AddAsync(TEntity product)
        {
            await _context.Set<TEntity>().AddAsync(product);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
