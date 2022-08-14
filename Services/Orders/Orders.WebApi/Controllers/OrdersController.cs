using Microsoft.AspNetCore.Mvc;
using Orders.Application.DTO;
using Orders.Application.Services;
using Orders.Domain.Models;

namespace Orders.WebApi.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [Route("getOrders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders(CancellationToken cancellationToken)
    {
        var res = await _orderService.GetAllOrdersAsync(cancellationToken);

        return Ok(res);
    }

    [HttpGet("{id}")]
    [Route("getOrder")]
    public async Task<ActionResult<Order>> GetOrder([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var res = await _orderService.GetOrderAsync(id, cancellationToken);

        return Ok(res);
    }

    [Route("createProduct")]
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        var res = await _orderService.CreateOrderAsync(orderDto, cancellationToken);

        return Ok(res);
    }

    [Route("updateProduct")]
    [HttpPut]
    public async Task<ActionResult<Order>> UpdateOrder([FromBody] UpdateOrderDto orderDto, CancellationToken cancellationToken)
    {
        var res = await _orderService.UpdateOrderAsync(orderDto, cancellationToken);

        return Ok(res);
    }

    [Route("deleteProduct")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _orderService.DeleteOrderAsync(id, cancellationToken);

        return NoContent();
    }
}