using TestBlazor.Server.Data;

namespace TestBlazor.Server.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly DataContext _dataContext;

    public CategoryService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<ServiceResponse<List<Category>>> GetCategories()
    {
        var response = await _dataContext.Categories.ToListAsync();

        return new ServiceResponse<List<Category>>
        {
            Data = response
        };
    }
}