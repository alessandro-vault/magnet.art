using API.Shared.Persistence.Contexts;
using API.Shared.Persistence.Repositories;
using API.Training.Domain.Models;
using API.Training.Domain.Repositories;

namespace API.Training.Repositories;

public class ProviderRepository : BaseRepository, IProviderRepository
{
    public ProviderRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<Provider> AddAsync(Provider provider)
    {
        await _context.Providers.AddAsync(provider);
    }

    public async Task<Provider> FindByIdAsync(int id)
    {
        return await _context.Providers.FindAsync(id);
    }


}