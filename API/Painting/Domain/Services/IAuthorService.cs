using API.Painting.Domain.Models;
using API.Painting.Domain.Services.Communication;

namespace API.Painting.Domain.Services;

public interface IAuthorService
{
    Task<IEnumerable<Author>> ListAsync();
    Task<AuthorResponse> SaveAsync(Author author);
}