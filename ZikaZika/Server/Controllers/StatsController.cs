using Microsoft.AspNetCore.Mvc;
using ZikaZika.Server.Services.StatsService;

namespace ZikaZika.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatsController : ControllerBase
{
    private readonly IStatsService _statsService;

    public StatsController(IStatsService statsService)
    {
        _statsService = statsService;
    }

    [HttpGet]
    public async Task<ActionResult<int>> GetVisits()
    {
        return await _statsService.GetVisits();
    }

    [HttpPost]
    public async Task IncrementVisits()
    {
        await _statsService.IncrementVisits();
    }
}