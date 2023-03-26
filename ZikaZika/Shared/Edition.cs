using System.ComponentModel.DataAnnotations;

namespace ZikaZika.Shared;

public class Edition
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}