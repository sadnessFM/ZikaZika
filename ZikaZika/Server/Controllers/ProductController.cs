using Microsoft.AspNetCore.Mvc;
using ZikaZika.Server.Services.ProductService;
using ZikaZika.Shared;

namespace ZikaZika.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("product")]
    public async Task<ActionResult> AddProduct(Product product)
    {
        return Ok(await _productService.AddProduct(product));
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        return Ok(await _productService.GetAllProducts());
    }

    [HttpGet("Category/{categoryUrl}")]
    public async Task<ActionResult<List<Product>>> GetProductsByCategory(string categoryUrl)
    {
        return Ok(await _productService.GetProductsByCategory(categoryUrl));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id) {
        return Ok(await _productService.GetProduct(id));
    }

    [HttpGet("Search/{searchText}")]
    public async Task<ActionResult<List<Product>>> SearchProducts(string searchText)
    {
        return Ok(await _productService.SearchProducts(searchText));
    }
}