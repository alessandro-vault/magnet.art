using API.Painting.Domain.Models;
using API.Painting.Domain.Services;
using API.Painting.Resources;
using API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Painting.Controllers;

[Route("/api/v1/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorsController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<AuthorResource>> GetAllAsync()
    {
        var authors = await _authorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Author>,
            IEnumerable<AuthorResource>>(authors);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAuthorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var author = _mapper.Map<SaveAuthorResource, Author>(resource);
        var result = await _authorService.SaveAsync(author);

        if (!result.Success)
            return BadRequest(result.Message);
        var authorResource = _mapper.Map<Author, AuthorResource>(result.Resource);

        return Ok(authorResource);

    }
}