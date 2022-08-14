﻿using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;
using Orders.Repository.Context;
using Orders.Repository.Contracts;
using System.Linq.Expressions;

namespace Orders.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
{
    protected OrdersContext _context;

    public RepositoryBase(OrdersContext context)
    {
        _context = context;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<T> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken)!;
    }

    public virtual async Task<T> CreateAsync(T model, CancellationToken cancellationToken)
    {
        var res = await _context.Set<T>().AddAsync(model, cancellationToken);

        return res.Entity;
    }

    public virtual async Task<Guid> DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Set<T>().Remove(entity);

        return entity.Id;
    }

    public virtual async Task<T> UpdateAsync(T model, CancellationToken cancellationToken)
    {
        var res = _context.Set<T>().Update(model);

        return res.Entity;
    }

    public virtual async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
