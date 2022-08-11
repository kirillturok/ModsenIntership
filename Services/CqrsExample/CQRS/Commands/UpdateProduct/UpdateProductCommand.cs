using MediatR;
using Repository.Entities;

namespace CqrsExample.CQRS.Commands.UpdateProduct;

public record UpdateProductCommand(Product product) : IRequest;
