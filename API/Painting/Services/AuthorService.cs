using API.Painting.Domain.Models;
using API.Painting.Domain.Repositories;
using API.Painting.Domain.Services;
using API.Painting.Domain.Services.Communication;
using API.Shared.Domain.Repositories;

namespace API.Painting.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Author>> ListAsync()
    {
        return await _authorRepository.ListAsync();
    }

    public async Task<AuthorResponse> SaveAsync(Author author)
    {
        if (await ValidateNickName(author.NickName))
            return new AuthorResponse("Author nickname already used");
        try
        {
            await _authorRepository.AddAsync(author);
  
            await _unitOfWork.CompleteAsync();

            return new AuthorResponse(author);
        }
        catch (Exception e)
        {
            return new AuthorResponse($"An error occurred while saving the author: {e.Message}");
        }
    }

    private async Task<bool> ValidateNickName(string nickname)
    {
        return await _authorRepository.FindByNickName(nickname) != null;
    }
}