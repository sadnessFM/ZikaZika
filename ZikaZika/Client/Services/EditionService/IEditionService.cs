using ZikaZika.Shared;

namespace ZikaZika.Client.Services.EditionService;

public interface IEditionService
{
    Task<Edition> GetEdition(int id);
    Task GetEditions();
}