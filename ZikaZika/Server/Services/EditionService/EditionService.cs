using Microsoft.EntityFrameworkCore;
using ZikaZika.Server.Data;
using ZikaZika.Shared;

namespace ZikaZika.Server.Services.EditionService;

public class EditionService : IEditionService
{
    private readonly DataContext _context;
    public EditionService(DataContext context)
    {
        _context=context;
    }

    public async Task<List<Edition>> GetEditions()
    {
        return await _context.Editions.ToListAsync();
    }

    public async Task<Edition> GetEdition(string name)
    {
        return await _context.Editions.
            FirstOrDefaultAsync(c => c.Name.ToLower().Equals(name.ToLower())) ?? throw new InvalidOperationException();
    }
}