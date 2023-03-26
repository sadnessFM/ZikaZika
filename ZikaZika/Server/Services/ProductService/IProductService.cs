using Microsoft.AspNetCore.Mvc;
using ZikaZika.Shared;

namespace ZikaZika.Server.Services.ProductService;

public interface IProductService
{
    Task<Product> AddProduct(Product product);
    Task<List<Product>> GetAllProducts();
    Task<List<Product>> GetProductsByCategory(string categoryUrl);
    Task<Product> GetProduct(int id);
    Task<List<Product>> SearchProducts(string searchText);
    Task<ProductVariant> AddProductVariant(ProductVariant variant);
}