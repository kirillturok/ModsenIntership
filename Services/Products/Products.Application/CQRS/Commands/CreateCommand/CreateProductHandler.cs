using AutoMapper;
using FluentValidation;
using MediatR;
using Products.Application.Validation;
using Products.Domain.Models;
using Products.Repository.Context;

namespace Products.Application.CQRS.Commands.CreateCommand;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly ProductsContext _context;
    private readonly IMapper _mapper;
    private readonly CreateProductValidator _createValidator;

    public CreateProductHandler(ProductsContext context, IMapper mapper, 
        CreateProductValidator validator) =>
        (_context, _mapper, _createValidator) = (context, mapper, validator);

    public async Task<Product> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        await _createValidator.ValidateAndThrowAsync(request, cancellationToken);
        var entity = _mapper.Map<Product>(request);
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
