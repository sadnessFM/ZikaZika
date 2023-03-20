using System.ComponentModel.DataAnnotations;

namespace ZikaZika.Shared.Models;

public class Product
{
    public int Id { get; set; }

    [Required, StringLength(128, MinimumLength = 1)]
    public string? Name { get; set; }

    [Required, DataType(DataType.Currency)]
    public double OriginalPrice { get; set; }

    [DataType(DataType.Currency)]
    public double NewPrice { get; set; }

    [StringLength(500, MinimumLength = 5)]
    public string? Description { get; set; }

    [Required]
    public bool InStock { get; set; }

    [Required]
    public DateTime UploadDate { get; set; } = DateTime.Now;

    [Required]
    public string? Image { get; set; }
}