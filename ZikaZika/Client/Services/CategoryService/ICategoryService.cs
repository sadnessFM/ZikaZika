using ZikaZika.Shared;

namespace ZikaZika.Client.Services.CategoryService;

internal interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task LoadCategories();
}