using API.Painting.Domain.Models;
using API.Shared.Domain.Services.Communication;

namespace API.Painting.Domain.Services.Communication;

public class AuthorResponse : BaseResponse<Author>
{
    public AuthorResponse(string message) : base(message)
    {
    }

    public AuthorResponse(Author resource) : base(resource)
    {
    }
}