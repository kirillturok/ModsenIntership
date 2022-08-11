using _3LayerExample.DTO;
using _3LayerExample.Exceptions;
using AutoMapper;
using Repository.Contracts;
using Repository.Entities;

namespace _3LayerExample.BusinessLogicLayer;

public class ProductBll
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ProductBll(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        var products = _repository.Product.GetAllProducts();
        return products;
    }

    public Product GetProductById(int id)
    {
        var productEntity = _repository.Product.GetProduct(id);
        return productEntity;
    }

    public Product CreateProduct(ProductForCreation prodForCreation)
    {

        var product = _mapper.Map<Product>(prodForCreation);
        _repository.Product.CreateProduct(product);
        return product;
    }

    public Product UpdateProduct(Product product)
    {
        if (product == null)
            throw new ValidationException("Product can't equal null");

        if (string.IsNullOrEmpty(product.Name))
        {
            throw new ValidationException("Wrong Name");
        }

        _repository.Product.UpdateProduct(product);
        return product;
    }

    public void DeleteProduct(Product product)
    {
        _repository.Product.DeleteProduct(product);
    }

}
