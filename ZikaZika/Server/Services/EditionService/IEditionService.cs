using ZikaZika.Shared;

namespace ZikaZika.Server.Services.EditionService;

public interface IEditionService
{
    Task<List<Edition>> GetEditions();
    Task<Edition> GetEdition(string name);
}