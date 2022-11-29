using API.Shared.Domain.Services.Communication;
using API.Training.Domain.Models;

namespace API.Training.Domain.Services.Communication;

public class ProviderResponse : BaseResponse<Provider>
{
    public ProviderResponse(string message) : base(message)
    {
    }

    public ProviderResponse(Provider resource) : base(resource)
    {
    }
}