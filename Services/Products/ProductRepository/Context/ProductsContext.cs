using Microsoft.EntityFrameworkCore;
using Products.Domain.Models;
using Products.Repository.Configuration;

namespace Products.Repository.Context;

public class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProductConfiguration());
    }
}
