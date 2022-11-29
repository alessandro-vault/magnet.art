using API.Painting.Domain.Models;

namespace API.Painting.Domain.Repositories;


public interface IAuthorRepository
{
    Task<IEnumerable<Author>> ListAsync();
    Task AddAsync(Author author);
}