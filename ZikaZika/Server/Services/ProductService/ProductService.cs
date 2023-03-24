using Microsoft.EntityFrameworkCore;
using ZikaZika.Server.Data;
using ZikaZika.Server.Services.CategoryService;
using ZikaZika.Shared;

namespace ZikaZika.Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly ICategoryService _categoryService;
    private readonly DataContext _context;

    public ProductService(ICategoryService categoryService, DataContext context)
    {
        _categoryService = categoryService;
        _context = context;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Products.Include(p => p.Variants).ToListAsync();
    }

    public async Task<Product> GetProduct(int id)
    {
        Product product = await _context.Products
            .Include(p => p.Variants)
            .ThenInclude(v => v.Edition)
            .FirstOrDefaultAsync(p => p.Id == id) ?? throw new InvalidOperationException();

        product.Views++;

        await _context.SaveChangesAsync();

        return product;
    }


    public async Task<List<Product>> GetProductsByCategory(string categoryUrl)
    {
        Category category = await _categoryService.GetCategoryByUrl(categoryUrl);
        return await _context.Products.Include(p => p.Variants).Where(p => p.CategoryId == category.Id).ToListAsync();
    }

    public async Task<List<Product>> SearchProducts(string searchText)
    {
        return await _context.Products
            .Where(p => p.Title.Contains(searchText) || p.Description.Contains(searchText))
            .ToListAsync();
    }

    public async Task<Product> AddProduct(Product product)
    {
        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Products ON");
        _context.Set<Product>().AsNoTracking();
        _context.AddRange(product);
        await _context.SaveChangesAsync();
        return product;
    }
}