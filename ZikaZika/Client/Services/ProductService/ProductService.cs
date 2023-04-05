using System.Net.Http.Json;
using ZikaZika.Shared;

namespace ZikaZika.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public event Action OnChange = null!;

    public List<Product> Products { get; set; } = new();

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task LoadProducts(string categoryUrl = null)
    {
        if (categoryUrl == null)
        {
            Products = await _http.GetFromJsonAsync<List<Product>>("api/Product") ?? throw new InvalidOperationException();
        }
        else
        {
            Products = await _http.GetFromJsonAsync<List<Product>>($"api/Product/Category/{categoryUrl}") ?? throw new InvalidOperationException();
        }
        OnChange.Invoke();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _http.GetFromJsonAsync<Product>($"api/Product/{id}") ?? throw new InvalidOperationException();
    }

    public async Task<List<Product>> SearchProducts(string searchText)
    {
        return await _http.GetFromJsonAsync<List<Product>>($"api/Product/Search/{searchText}") ?? throw new InvalidOperationException();
    }

    public async Task<HttpResponseMessage> AddProduct(Product product)
    {
        return await _http.PostAsJsonAsync("api/ProductController/AddProduct/", product);
    }
}

/*
 public async Task<Product> AddProduct(Product product)
    {
        string jsonProduct = JsonSerializer.Serialize(product);
        StringContent content = new(jsonProduct, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _http.PostAsync($"api/ProductController/AddProduct/{product}", content);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Product>(responseBody) ?? throw new InvalidOperationException();
    }
*/