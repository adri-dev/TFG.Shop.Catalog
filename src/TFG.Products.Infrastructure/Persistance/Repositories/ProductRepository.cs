using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TFG.Products.Application.Abstractions.Repositories;
using TFG.Products.Domain.Entities;
using TFG.Products.Infrastructure.Persistance.Contexts;
using TFG.Products.Infrastructure.Persistance.Repositories.Base;

namespace TFG.Products.Infrastructure.Persistance.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductsDbContext context) : base(context)
        {
        }
    }
}
