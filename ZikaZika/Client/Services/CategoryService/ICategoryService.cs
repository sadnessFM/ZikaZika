using ZikaZika.Shared;

namespace ZikaZika.Client.Services.CategoryService;

interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task LoadCategories();
}