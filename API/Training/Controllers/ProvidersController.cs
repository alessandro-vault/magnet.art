
using API.Shared.Extensions;
using API.Training.Domain.Models;
using API.Training.Domain.Services;
using API.Training.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Training.Controllers;

[Route("/api/v1/[controller]")]
public class ProvidersController : ControllerBase
{
    private readonly IProviderService _providerService;
    private readonly IMapper _mapper;

    public ProvidersController(IProviderService providerService, IMapper mapper)
    {
        _providerService = providerService;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var provider = await _providerService.FindById(id);
            return Ok(provider);
        }
        catch (Exception e)
        {
            return BadRequest($"{e.Message}");
        }
        
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProviderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var provider = _mapper.Map<SaveProviderResource, Provider>(resource);
        var result = await _providerService.SaveAsync(provider);

        if (!result.Success)
            return BadRequest(result.Message);
        var providerResource = _mapper.Map<Provider, ProviderResource>(result.Resource);

        return Ok(providerResource);

    }
}