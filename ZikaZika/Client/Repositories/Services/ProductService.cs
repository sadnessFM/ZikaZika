using System.Net.Http.Json;
using ZikaZika.Client.Repositories.Interfaces;
using ZikaZika.Shared.DTO;
using ZikaZika.Shared.Models;

namespace ZikaZika.Client.Repositories.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public ProductService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ServiceModel?> AddProduct(Product newProduct)
    {
        var product = await _client.PostAsJsonAsync("api/Product/AddProduct", newProduct);
        return await product.Content.ReadFromJsonAsync<ServiceModel>();
    }

    public async Task<ServiceModel?> GetProduct(int id)
    {
        var product = await _client.GetAsync($"api/Product/GetProduct/getProduct/{id}");
        return await product.Content.ReadFromJsonAsync<ServiceModel>();
    }

    public async Task<ServiceModel?> GetProducts()
    {
        var product = await _client.GetAsync($"api/Product/GetProduct/getProducts");
        return await product.Content.ReadFromJsonAsync<ServiceModel>();
    }
}