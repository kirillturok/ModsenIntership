using CqrsExample.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CqrsExample;

public sealed class RepositoryContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public RepositoryContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}


