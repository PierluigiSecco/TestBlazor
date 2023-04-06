using Microsoft.AspNetCore.Mvc;
using TestBlazor.Server.Services.ProductService;

namespace TestBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        var products = await _productService.GetProducts();
        
        return Ok(products);
    }
}