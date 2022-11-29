using API.Training.Domain.Models;
using API.Training.Resources;
using AutoMapper;

namespace API.Training.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Provider, ProviderResource>();
    }
}