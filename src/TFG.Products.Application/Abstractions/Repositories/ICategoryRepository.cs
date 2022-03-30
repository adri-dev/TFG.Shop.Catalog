using TFG.Products.Application.Abstractions.Repositories.Base;
using TFG.Products.Domain.Entities;

namespace TFG.Products.Application.Abstractions.Repositories
{
    public interface ICategoryRepository : ICategoryReadOnlyRepository, IRepository<Category> { }
}
