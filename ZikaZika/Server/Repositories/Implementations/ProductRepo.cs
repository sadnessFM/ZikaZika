using Microsoft.EntityFrameworkCore;
using ZikaZika.Server.Data;
using ZikaZika.Server.Repositories.Interfaces;
using ZikaZika.Shared.DTO;
using ZikaZika.Shared.Models;

namespace ZikaZika.Server.Repositories.Implementations;

public class ProductRepo : IProductRepo
{
    private readonly AppDbContext _appDbContext;

    public ProductRepo(AppDbContext context)
    {
       _appDbContext = context;
    }
    public async Task<ServiceModel> AddProduct(Product? product)
    {
        var responce = new ServiceModel();
        if (product != null)
        {
            try
            {
                _appDbContext.Products.Add(product);
                await _appDbContext.SaveChangesAsync();

                responce.Tovar = product;
                responce.Message = "added";
                responce.CssClass = "success";
                return responce;

            }
            catch (Exception ex)
            {
                responce.CssClass += "error";
                responce.Message = ex.Message;
                return responce;
            }
        }

        responce.Success = false;
        responce.Message = "empty";
        responce.CssClass = "warning";
        responce.Tovar = null!;
        return responce;
    }

    public async Task<ServiceModel> GetProducts()
    {
        var responce = new ServiceModel();
        try
        {
            var products = await _appDbContext.Products.ToListAsync();
            if (products == null)
            {
                responce.Success = false;
                responce.Message = "every unreal";
                responce.CssClass = "info";
                responce.Tovars = null!;
                return responce;
            }

            responce.Success = true;
            responce.Message = "every real";
            responce.CssClass = "success";
            responce.Tovars = products;
            return responce;
        }
        catch (Exception ex)
        {
            responce.CssClass += "error";
            responce.Message = ex.Message;
            return responce;
        }

    }

    public async Task<ServiceModel> GetProduct(int productId)
    {
        var responce = new ServiceModel();
        if (productId > 0)
        {
            try
            {
                Product? product = await _appDbContext.Products.SingleOrDefaultAsync(p => p.Id == productId);
                if (product == null)
                {
                    responce.Success = false;
                    responce.Message = "unreal";
                    responce.CssClass = "info";
                    responce.Tovar = null!;
                    return responce;
                }

                responce.Success = true;
                responce.Message = "real";
                responce.CssClass = "success";
                responce.Tovar = product;
                return responce;
            }
            catch (Exception ex)
            {
                responce.CssClass += "error";
                responce.Message = ex.Message;
                return responce;
            }
        }
        responce.Success = false;
        responce.Message = "empty";
        responce.CssClass = "warning";
        responce.Tovar = null!;
        return responce;
    }
}