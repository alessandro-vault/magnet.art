using API.Painting.Domain.Models;
using API.Painting.Domain.Repositories;
using API.Shared.Persistence.Contexts;
using API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Painting.Repositories;

public class AuthorRepository : BaseRepository, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Author>> ListAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task AddAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
    }


}