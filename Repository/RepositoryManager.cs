using Repository.Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly IProductRepository _productRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _productRepository = new ProductRepository(_repositoryContext);
    }

    public IProductRepository Product => _productRepository;

    public void Save() => _repositoryContext.SaveChanges();
}
