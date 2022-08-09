using CqrsExample.Exceptions;
using MediatR;

namespace CqrsExample.CQRS.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly RepositoryContext _context;

    public DeleteProductHandler(RepositoryContext context) =>
        _context = context;

    public async Task<Unit> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
