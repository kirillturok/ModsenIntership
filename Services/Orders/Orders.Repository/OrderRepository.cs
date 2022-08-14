using Orders.Domain.Models;
using Orders.Repository.Context;
using Orders.Repository.Contracts;

namespace Orders.Repository;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrdersContext context) : base(context)
    {
    }
}
