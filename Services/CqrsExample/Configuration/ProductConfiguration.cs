using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace CqrsExample.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Product 1",
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
            }
        );
    }
}
