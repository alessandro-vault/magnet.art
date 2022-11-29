using API.Painting.Domain.Models;
using API.Painting.Resources;
using AutoMapper;
namespace API.Painting.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Author, AuthorResource>();
    }
}