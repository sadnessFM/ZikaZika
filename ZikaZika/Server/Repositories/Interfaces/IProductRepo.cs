using ZikaZika.Shared.DTO;
using ZikaZika.Shared.Models;

namespace ZikaZika.Server.Repositories.Interfaces;

public interface IProductRepo
{
    public Task<ServiceModel> AddProduct(Product? product);
    public Task<ServiceModel> GetProducts();
    public Task<ServiceModel> GetProduct(int productId);
}