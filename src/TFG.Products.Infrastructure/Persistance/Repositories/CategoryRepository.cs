using TFG.Products.Application.Abstractions.Repositories;
using TFG.Products.Domain.Entities;
using TFG.Products.Infrastructure.Persistance.Contexts;
using TFG.Products.Infrastructure.Persistance.Repositories.Base;

namespace TFG.Products.Infrastructure.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductsDbContext context) : base(context)
        {
        }
    }
}
