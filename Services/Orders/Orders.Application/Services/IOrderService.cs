using Products.Application.DTO;
using Products.Domain.Models;

namespace Products.Application.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken);
    Task<Order> GetOrderAsync(Guid id, CancellationToken cancellationToken);
    Task<Order> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken);
    Task<Order> UpdateOrderAsync(UpdateOrderDto orderDto, CancellationToken cancellationToken);
    Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken);
}
