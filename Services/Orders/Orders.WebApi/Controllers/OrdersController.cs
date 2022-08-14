using Microsoft.AspNetCore.Mvc;
using Orders.Application.DTO;
using Orders.Application.Services;
using Orders.Domain.Models;

namespace Orders.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[ApiExplorerSettings(GroupName = "Events")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("getOrders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders(CancellationToken cancellationToken)
    {
        var res = await _orderService.GetAllOrdersAsync(cancellationToken);

        return Ok(res);
    }

    [HttpGet("getOrder/{id}")]
    public async Task<ActionResult<Order>> GetOrder([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var res = await _orderService.GetOrderAsync(id, cancellationToken);

        return Ok(res);
    }

    [HttpPost("createOrder")]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderDto orderDto, CancellationToken cancellationToken)
    {
        var res = await _orderService.CreateOrderAsync(orderDto, cancellationToken);

        return Ok(res);
    }

    [HttpPut("updateOrder")]
    public async Task<ActionResult<Order>> UpdateOrder([FromBody] UpdateOrderDto orderDto, CancellationToken cancellationToken)
    {
        var res = await _orderService.UpdateOrderAsync(orderDto, cancellationToken);

        return Ok(res);
    }

    [HttpDelete("deleteOrder/{id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _orderService.DeleteOrderAsync(id, cancellationToken);

        return NoContent();
    }
}