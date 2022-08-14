using AutoMapper;
using FluentValidation;
using Products.Application.DTO;
using Products.Application.Exceptions;
using Products.Application.Validation;
using Products.Domain.Models;
using Products.Repository.Contracts;

namespace Products.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    private readonly CreateOrderValidator _createValidator;
    private readonly UpdateOrderValidator _updateValidator;

    public OrderService(IOrderRepository repository, IMapper mapper,
        CreateOrderValidator createValidator, UpdateOrderValidator updateValidator)
        => (_repository, _mapper, _createValidator, _updateValidator)
        = (repository, mapper, createValidator, updateValidator);

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken)
    {
        var orders = await _repository.GetAllAsync(cancellationToken);
        return orders;
    }

    public async Task<Order> GetOrderAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await _repository.GetAsync(id, cancellationToken);
        return order;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        await _createValidator.ValidateAndThrowAsync(orderDto, cancellationToken);
        var order = _mapper.Map<Order>(orderDto);
        var result = await _repository.CreateAsync(order, cancellationToken);
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }

        await _repository.SaveAsync(cancellationToken);

        return result;
    }

    public async Task<Order> UpdateOrderAsync(UpdateOrderDto orderDto, CancellationToken cancellationToken)
    {
        await _updateValidator.ValidateAndThrowAsync(orderDto, cancellationToken);
        var order = _mapper.Map<Order>(orderDto);
        var result = await _repository.UpdateAsync(order, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
        return result;
    }

    public async Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(id, cancellationToken);

        if (entity is null)
        {
            throw new NotFoundException(nameof(entity));
        }

        await _repository.DeleteAsync(entity, cancellationToken);

        await _repository.SaveAsync(cancellationToken);
    }
}