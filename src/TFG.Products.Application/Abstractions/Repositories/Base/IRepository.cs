using TFG.Products.Domain.Entities;

namespace TFG.Products.Application.Abstractions.Repositories.Base
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity product);
        Task SaveChangesAsync();
    }
}
