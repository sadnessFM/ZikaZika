using ZikaZika.Shared.Models;

namespace ZikaZika.Shared.DTO;

public class ServiceModel
{
    public List<Product?> Tovars { get; set; } = null!;
    public Product? Tovar { get; set; } = null!;
    public bool Success { get; set; } = true;
    public string CssClass { get; set; } = "success";
    public string Message { get; set; } = null!;
}