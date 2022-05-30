using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TFG.Products.Application.Abstractions.Repositories;
using TFG.Products.Domain.Entities;
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


        public static void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProductsDbContext>();
                context.Database.Migrate();
            }
        }

        public static void SeedDatabase(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProductsDbContext>();

                if(!context.Categories.Any())
                {
                    context.Categories.AddRange(new Category("Category 1", "This is the First category")
                                                    .AddProduct("Product 1", "This is the First Product", ""),
                                                new Category("Category 2", "This is the Second category")
                                                    .AddProduct("Product 2", "This is the Second Product", ""));

                    context.SaveChanges();
                }

                context.Database.Migrate();
            }
        }
    }
}
