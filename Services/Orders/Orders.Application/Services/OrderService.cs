using AutoMapper;
using Orders.Application.DTO;
using Orders.Application.Validation;
using Orders.Domain.Models;
using Repository.Contracts;
using FluentValidation;

namespace Orders.Application.Services;

public class OrderService : IOrderService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly CreateOrderValidator _createValidator;
    private readonly UpdateOrderValidator _updateValidator;

    public OrderService(IRepositoryManager repository, IMapper mapper,
        CreateOrderValidator createValidator, UpdateOrderValidator updateValidator)
        => (_repository, _mapper, _createValidator, _updateValidator)
        = (repository, mapper, createValidator, updateValidator);

    public Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken)
    {
        var orders = _repository.Order.GetAllProducts();
        return orders;
    }

    public Task<Order> GetOrderAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = _repository.Order.GetProduct(id);
        return order;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        await _createValidator.ValidateAndThrowAsync(orderDto, cancellationToken);
        var order = _mapper.Map<Order>(orderDto);
        _repository.Order.CreateOrder(order);
        await _repository.Order.Save();
        return order;
    }

    public async Task<Order> UpdateOrderAsync(UpdateOrderDto orderDto, CancellationToken cancellationToken)
    {
        await _updateValidator.ValidateAndThrowAsync(orderDto, cancellationToken);
        var order = _mapper.Map<Order>(orderDto);
        _repository.Order.UpdateOrder(order);
        await _repository.Order.Save();
        return order;
    }

    public async Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repository.Order.DeleteOrder(id, cancellationToken);
        await _repository.Order.Save();
    }
}