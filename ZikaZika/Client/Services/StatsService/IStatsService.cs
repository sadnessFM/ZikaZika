namespace ZikaZika.Client.Services.StatsService;

interface IStatsService
{
    Task GetVisits();
    Task IncrementVisits();
}