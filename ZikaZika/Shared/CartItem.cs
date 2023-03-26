using System.ComponentModel.DataAnnotations;

namespace ZikaZika.Shared;

public class CartItem
{
    public int ProductId { get; set; }
    public int EditionId { get; set; }
    [Required] 
    public string ProductTitle { get; set; } = null!;
    [Required] 
    public string EditionName { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Image { get; set; } = null!;
    public int Quantity { get; set; }
}