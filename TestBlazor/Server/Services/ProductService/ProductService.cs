using TestBlazor.Server.Data;

namespace TestBlazor.Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _dataContext;

    public ProductService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<ServiceResponse<List<Product>>> GetProducts()
    {
        var products = await _dataContext.Products.ToListAsync();

        return new ServiceResponse<List<Product>>()
            {
                Data = products
            };
    }

    public async Task<ServiceResponse<Product>> GetProductById(int productId)
    {
        var product = await _dataContext.Products.SingleOrDefaultAsync(x => x.Id ==  productId);

        return new ServiceResponse<Product>()
        {
            Data = product
        };
    }

    public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl)
    {
        var products = await _dataContext.Products
            .Where(x => x.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
            .ToListAsync();

        return new ServiceResponse<List<Product>>
        {
            Data = products
        };
    }

    public async Task<Product> CreateProduct(Product product)
    {
        _dataContext.Products.Add(product);
        await _dataContext.SaveChangesAsync();

        product.Category = await _dataContext.Categories.FirstOrDefaultAsync(x => x.Id == product.CategoryId);

        return product;
    }
}