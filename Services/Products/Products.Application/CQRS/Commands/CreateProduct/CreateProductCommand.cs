using MediatR;
using Products.Domain.Models;

namespace Products.Application.CQRS.Commands.CreateProduct;

public record CreateProductCommand(string Name) : IRequest<Product>;
