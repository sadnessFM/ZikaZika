using System.Net.Http.Json;
using ZikaZika.Shared;

namespace ZikaZika.Client.Services.EditionService;

public class EditionService : IEditionService
{
    private readonly HttpClient _http;
    List<Edition> editions = new();

    public EditionService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetEditions()
    {
        editions = await _http.GetFromJsonAsync<List<Edition>>("api/Edition") ?? throw new InvalidOperationException();
    }

    public async Task<Edition> GetEdition(int id)
    {
        return await _http.GetFromJsonAsync<Edition>($"api/Edition/{id}") ?? throw new InvalidOperationException();
    }
}