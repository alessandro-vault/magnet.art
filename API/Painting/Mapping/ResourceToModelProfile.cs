using AutoMapper;
using API.Painting.Domain.Models;
using API.Painting.Resources;

namespace API.Painting.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAuthorResource, Author>();
    }
}