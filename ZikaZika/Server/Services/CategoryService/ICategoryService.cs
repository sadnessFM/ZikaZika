using ZikaZika.Shared;

namespace ZikaZika.Server.Services.CategoryService;

public interface ICategoryService
{
    Task<List<Category>> GetCategories();

    Task<Category> GetCategoryByUrl(string categoryUrl);
}