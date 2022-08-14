using MediatR;
using Products.Domain.Models;

namespace Products.Application.CQRS.Commands.UpdateProduct;

public record UpdateProductCommand(Product product) : IRequest;
