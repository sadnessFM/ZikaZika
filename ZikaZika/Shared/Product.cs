namespace ZikaZika.Shared;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = "https://via.placeholder.com/300x300";
    public int CategoryId { get; set; }
    public List<ProductVariant> Variants { get; set; } = new();
    public DateTime? DateCreated { get; set; } = DateTime.Now;
    public int Views { get; set; }
    /*
    public bool IsPublic { get; set; }
    public bool IsDeleted { get; set; }
    public Category Category { get; set; }
    public DateTime? DateUpdated { get; set; }
    */
}