using System.Net.Http.Json;
using ZikaZika.Shared;

namespace ZikaZika.Client.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _http;

    public List<Category> Categories { get; set; } = new();

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task LoadCategories()
    {
        Categories = await _http.GetFromJsonAsync<List<Category>>("api/Category");
    }
}