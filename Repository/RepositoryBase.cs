using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System.Linq.Expressions;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly RepositoryContext _repositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

    public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);

    public IQueryable<T> FindAll() => _repositoryContext.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) 
        => _repositoryContext.Set<T>().Where(expression);

    public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);
}
