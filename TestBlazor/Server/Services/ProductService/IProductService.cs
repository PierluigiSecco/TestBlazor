﻿namespace TestBlazor.Server.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProducts();
    Task<ServiceResponse<Product>> GetProductById(int productId);
}