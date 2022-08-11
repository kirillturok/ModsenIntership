using MediatR;
using Repository.Entities;

namespace CqrsExample.CQRS.Commands.CreateProduct;

public record CreateProductCommand(string Name) : IRequest<Product>;
