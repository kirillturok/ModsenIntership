using Products.Domain.Models;
using Products.Repository.Context;
using Products.Repository.Contracts;

namespace Products.Repository;

public class ProductsRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductsRepository(ProductsContext context) : base(context)
    {
    }
}
