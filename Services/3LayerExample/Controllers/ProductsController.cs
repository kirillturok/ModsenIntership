using _3LayerExample.BusinessLogicLayer;
using _3LayerExample.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace _3LayerExample.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly ProductBll _bll;

    public ProductsController(ProductBll bll)
    {
        _bll = bll;
    }

    [HttpGet]
    [Route("getProducts")]
    public IEnumerable<Product> GetAllProducts()
    {
        return _bll.GetAllProducts();
    }

    [HttpGet]
    [Route("getProduct")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _bll.GetProductById(id);

        if (product == null)
        {
            return NotFound("Invalid ID");
        }

        return Ok(product);
    }

    [Route("createProduct")]
    [HttpPost]
    public void CreateProduct([FromBody] ProductForCreation prodForCreation)
    {
        _bll.CreateProduct(prodForCreation);
    }

    [Route("updateProduct")]
    [HttpPost]
    public void UpdateProduct([FromBody] Product product)
    {
        _bll.UpdateProduct(product);
    }
 
    [Route("deleteProduct")]
    [HttpDelete]
    public void deleteProduct(Product product)
    {
        _bll.DeleteProduct(product);
    }
}
