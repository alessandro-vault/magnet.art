using API.Shared.Domain.Repositories;
using API.Training.Domain.Models;
using API.Training.Domain.Repositories;
using API.Training.Domain.Services;
using API.Training.Domain.Services.Communication;

namespace API.Training.Services;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _providerRepository;
    private readonly IUnitOfWork _unitOfWork;


    public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    {
        _providerRepository = providerRepository;
        _unitOfWork = unitOfWork;
    }
    

    public Task<ProviderResponse> SaveAsync(Provider provider)
    {
        throw new NotImplementedException();
    }

    public async Task<Provider> FindById(int id)
    {
        return await _providerRepository.FindByIdAsync(id);
    }
}