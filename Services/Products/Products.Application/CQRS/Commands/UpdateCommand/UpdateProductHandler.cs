using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Products.Application.Exceptions;
using Products.Application.Validation;
using Products.Domain.Models;
using Products.Repository.Context;

namespace Products.Application.CQRS.Commands.UpdateCommand;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly ProductsContext _context;
    private readonly UpdateProductValidator _updateValidator;

    public UpdateProductHandler(ProductsContext dbContext, UpdateProductValidator validator)
    {
        _context = dbContext;
        _updateValidator = validator;
    }

    public async Task<Unit> Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        await _updateValidator.ValidateAndThrowAsync(request, cancellationToken);
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
