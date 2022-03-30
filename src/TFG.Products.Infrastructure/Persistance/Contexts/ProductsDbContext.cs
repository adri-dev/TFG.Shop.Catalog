using Microsoft.EntityFrameworkCore;
using TFG.Products.Domain.Entities;

namespace TFG.Products.Infrastructure.Persistance.Contexts
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public ProductsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);
        }
    }
}
