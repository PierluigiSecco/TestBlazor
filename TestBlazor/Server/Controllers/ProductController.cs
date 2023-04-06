using Microsoft.AspNetCore.Mvc;
using TestBlazor.Server.Data;

namespace TestBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DataContext _dataContext;

    public ProductController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await _dataContext.Products.ToListAsync());
    }
}