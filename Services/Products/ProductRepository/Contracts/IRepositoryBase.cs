using Products.Domain.Models;

namespace Products.Repository.Contracts;

public interface IRepositoryBase<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<T> CreateAsync(T model, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T model, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(T model, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
