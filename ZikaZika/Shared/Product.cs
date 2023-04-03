﻿using System.Text.Json.Serialization;

namespace ZikaZika.Shared;

public class Product
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; } = "https://via.placeholder.com/300x300";
    public int CategoryId { get; set; }
    [JsonIgnore]
    public List<ProductVariant> Variants { get; set; } = new();
    public DateTime? DateCreated { get; set; } = DateTime.Now;
    public int Views { get; set; }
    public bool IsPublic { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    //public Category Category { get; set; }
    public DateTime? DateUpdated { get; set; } = DateTime.Now;
}