using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.CQRS.Commands.CreateProduct;
using Products.Application.CQRS.Commands.DeleteProduct;
using Products.Application.CQRS.Commands.UpdateProduct;
using Products.Application.CQRS.Queries.GetProductById;
using Products.Application.CQRS.Queries.GetProducts;
using Products.Domain.Models;

namespace CqrsExample.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet("getProducts")]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpGet("getProduct{id}")]
    public async Task<ActionResult> GetProductById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPost("AddProduct")]
    public async Task<ActionResult> AddProduct(CreateProductCommand product)
    {
        var productToReturn = await _mediator.Send(product);
        return Ok(productToReturn);
    }

    [HttpPut("updateProduct")]
    public async Task<ActionResult> UpdateProduct([FromBody] Product product)
    {
        var productToReturn = await _mediator.Send(new UpdateProductCommand(product));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProductCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}


