using Repository.Contracts;
using Repository.Entities;

namespace Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public IEnumerable<Product> GetAllProducts()
        => FindAll().OrderBy(c => c.Name).ToList();

    public Product GetProduct(int eventId)
    => FindByCondition(c => c.Id.Equals(eventId)).SingleOrDefault();

    public void CreateProduct(Product product)
    {
        Create(product);
    }

    public void UpdateProduct(Product product)
    {
        Update(product);
    }

    public void DeleteProduct(Product ev)
    {
        Delete(ev);
    }
}

