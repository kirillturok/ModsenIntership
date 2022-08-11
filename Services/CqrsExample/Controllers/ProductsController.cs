using CqrsExample.CQRS.Commands.CreateProduct;
using CqrsExample.CQRS.Commands.DeleteProduct;
using CqrsExample.CQRS.Commands.UpdateProduct;
using CqrsExample.CQRS.Queries.GetProductById;
using CqrsExample.CQRS.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace CqrsExample.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPost("AddProduct")]
    public async Task<ActionResult> AddProduct(CreateProductCommand product)
    {
        var productToReturn = await _mediator.Send(product);
        return CreatedAtRoute("GetProductById", new { productToReturn.Id }, productToReturn);
    }

    [HttpPost("updateProduct")]
    public async Task<ActionResult> UpdateProduct([FromBody] Product product)
    {
        var productToReturn = await _mediator.Send(new UpdateProductCommand(product));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}


