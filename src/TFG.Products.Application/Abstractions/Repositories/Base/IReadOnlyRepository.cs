using System.Linq.Expressions;
using TFG.Products.Domain.Entities;

namespace TFG.Products.Application.Abstractions.Repositories.Base
{
    public interface IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, params string[] includeProperties);
        Task<IList<TEntity>> GetAllAsync();
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}
