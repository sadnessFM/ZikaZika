using Microsoft.AspNetCore.Mvc;
using ZikaZika.Server.Services.EditionService;
using ZikaZika.Shared;

namespace ZikaZika.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EditionController : ControllerBase
{
    private readonly IEditionService _service;

    public EditionController(IEditionService iEditionService)
    {
        _service = iEditionService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetCategories()
    {
        return Ok(await _service.GetEditions());
    }

    [HttpGet]
    public async Task<ActionResult<Edition>> GetEdition(string name)
    {
        return Ok(await _service.GetEdition(name));
    }
}