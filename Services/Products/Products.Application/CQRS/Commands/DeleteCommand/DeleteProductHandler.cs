using MediatR;
using Products.Application.Exceptions;
using Products.Domain.Models;
using Products.Repository.Context;

namespace Products.Application.CQRS.Commands.DeleteCommand;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly ProductsContext _context;

    public DeleteProductHandler(ProductsContext context) =>
        _context = context;

    public async Task<Unit> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Products.
            FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
