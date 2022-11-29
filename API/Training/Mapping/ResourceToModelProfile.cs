using API.Training.Domain.Models;
using API.Training.Resources;
using AutoMapper;

namespace API.Training.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProviderResource, Provider>();
    }
}