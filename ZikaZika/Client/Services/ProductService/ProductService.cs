using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ZikaZika.Shared;

namespace ZikaZika.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public event Action OnChange;

    public List<Product> Products { get; set; } = new();

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task LoadProducts(string categoryUrl = null)
    {
        if (categoryUrl == null)
        {
            Products = await _http.GetFromJsonAsync<List<Product>>("api/Product");
        }
        else
        {
            Products = await _http.GetFromJsonAsync<List<Product>>($"api/Product/Category/{categoryUrl}");
        }
        OnChange.Invoke();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _http.GetFromJsonAsync<Product>($"api/Product/{id}");
    }

    public async Task<List<Product>> SearchProducts(string searchText)
    {
        return await _http.GetFromJsonAsync<List<Product>>($"api/Product/Search/{searchText}");
    }

    public async Task<Product> AddProduct(Product product)
    {
        string jsonProduct = JsonSerializer.Serialize(product);
        StringContent content = new(jsonProduct, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _http.PostAsync($"api/ProductController/AddProduct/{product}", content);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Product>(responseBody) ?? throw new InvalidOperationException();
    }
}

/* XHRPOSThttps://localhost:44332/api/ProductController/AddProduct/ZikaZika.Shared.Product
[HTTP/2 405 Method Not Allowed 4ms]

 
1

{
"Title":"fsdfsadf",
"Description":"dvsdfvdf",
"Image":"https://via.placeholder.com/300x300",
"CategoryId":3,
"DateCreated":"2023-04-03T12:40:11.415+03:00",
"Views":0,
"IsPublic":false,
"IsDeleted":false,
"DateUpdated":"2023-04-03T12:40:11.431+03:00"
}


*/