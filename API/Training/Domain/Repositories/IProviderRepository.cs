using API.Training.Domain.Models;

namespace API.Training.Domain.Repositories;

public interface IProviderRepository
{
    Task AddAsync(Provider provider);
    Task<Provider> FindByIdAsync(int id);
}