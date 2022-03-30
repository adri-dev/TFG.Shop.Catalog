using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TFG.Products.Application.Abstractions.Repositories;
using TFG.Products.Infrastructure.Persistance.Contexts;
using TFG.Products.Infrastructure.Persistance.Repositories;

namespace TFG.Products.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ProductsDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("ProductsDb")))
                .AddScoped<ICategoryReadOnlyRepository, CategoryRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IProductReadOnlyRepository, ProductRepository>()
                .AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
