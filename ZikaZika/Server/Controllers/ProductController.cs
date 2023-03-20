using Microsoft.AspNetCore.Mvc;
using ZikaZika.Server.Repositories.Implementations;
using ZikaZika.Server.Repositories.Interfaces;
using ZikaZika.Shared.DTO;
using ZikaZika.Shared.Models;

namespace ZikaZika.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepo _repo;

    public ProductController(IProductRepo repo)
    {
        _repo = repo;
    }

    [HttpPost("AddProduct")]
    public async Task<ActionResult<ServiceModel>> AddProduct(Product product)
    {
        return Ok(await _repo.AddProduct(product));
    }

    [HttpGet("getProduct/{id:int}")]
    public async Task<ActionResult<ServiceModel>> GetProduct(int id)
    {
        return Ok(await _repo.GetProduct(id));
    }

    [HttpGet("GetProducts")]
    public async Task<ActionResult<ServiceModel>> GetProducts()
    {
        return Ok(await _repo.GetProducts());
    }
 }