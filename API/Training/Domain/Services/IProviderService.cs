using API.Training.Domain.Models;
using API.Training.Domain.Services.Communication;

namespace API.Training.Domain.Services;

public interface IProviderService
{
    Task<ProviderResponse> SaveAsync(Provider provider);
    Task<Provider> FindById(int id);
}