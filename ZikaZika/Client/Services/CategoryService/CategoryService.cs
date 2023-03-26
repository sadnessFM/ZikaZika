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
        Categories = await _http.GetFromJsonAsync<List<Category>>("api/Category") ?? throw new InvalidOperationException();
    }

    public async Task<List<Category>> LoadCategoriesNames()
    {
        return await _http.GetFromJsonAsync<List<Category>>("api/Category") ?? throw new InvalidOperationException();
    }
}