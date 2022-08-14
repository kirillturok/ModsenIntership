using Products.Domain.Models;
using Products.Repository.Context;
using Products.Repository.Contracts;

namespace Products.Repository;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrdersContext context) : base(context)
    {
    }
}
