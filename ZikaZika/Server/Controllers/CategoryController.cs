using Microsoft.AspNetCore.Mvc;
using ZikaZika.Server.Services.CategoryService;
using ZikaZika.Shared;

namespace ZikaZika.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetCategories()
    {
        return Ok(await _categoryService.GetCategories());
    }
}