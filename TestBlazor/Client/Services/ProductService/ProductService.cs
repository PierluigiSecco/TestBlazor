using System.Net.Http.Json;
using TestBlazor.Shared;

namespace TestBlazor.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public List<Product> Products { get; set; } = new List<Product>();

    public async Task GetProducts()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
        if(response != null && response.Data != null) Products = response.Data;
    }

    public async Task<ServiceResponse<Product>> GetProduct(int id)
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{id}");
        if (response == null && response.Data == null)
            response.Message = "Something went wrong loading product detailed";

        return response;
    }
}