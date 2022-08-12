using Repository.Entities;

namespace Repository.Contracts;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product GetProduct(int productId);
    void CreateProduct(Product pr);
    void UpdateProduct(Product pr);
    void DeleteProduct(Product pr);
}
