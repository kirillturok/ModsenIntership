using CqrsExample.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;

namespace CqrsExample.CQRS.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly RepositoryContext _context;

    public UpdateProductHandler(RepositoryContext dbContext) =>
        _context = dbContext;

    public async Task<Unit> Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var entity =
            await _context.Products.FirstOrDefaultAsync(note =>
                note.Id == request.product.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.product.Id);
        }

        entity.Name = request.product.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
