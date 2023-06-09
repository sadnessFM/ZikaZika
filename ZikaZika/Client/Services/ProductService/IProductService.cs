﻿using ZikaZika.Shared;

namespace ZikaZika.Client.Services.ProductService;

public interface IProductService
{
    event Action OnChange;
    List<Product> Products { get; set; }
    Task LoadProducts(string categoryUrl = null);
    Task<Product> GetProduct(int id);
    Task<List<Product>> SearchProducts(string searchText);
    Task<HttpResponseMessage> AddProduct(Product product);
    Task<List<Product>> SortBy(Sort sorting = Sort.NameAsc);
}