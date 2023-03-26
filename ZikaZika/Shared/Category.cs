using System.ComponentModel.DataAnnotations;

namespace ZikaZika.Shared;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Url { get; set; } = null!;
    [Required]
    public string Icon { get; set; } = null!;
}