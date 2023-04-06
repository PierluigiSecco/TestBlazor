using Microsoft.AspNetCore.Mvc;
using TestBlazor.Server.Services.CategoryService;

namespace TestBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAllCategories()
    {
        var response = await _categoryService.GetCategories();
        return Ok(response);
    }
}