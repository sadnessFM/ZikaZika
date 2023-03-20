using ZikaZika.Shared.DTO;
using ZikaZika.Shared.Models;

namespace ZikaZika.Client.Repositories.Interfaces;

public interface IProductService
{
    public Task<ServiceModel?> AddProduct(Product product);
    public Task<ServiceModel?> GetProduct(int id);
    public Task<ServiceModel?> GetProducts();
}