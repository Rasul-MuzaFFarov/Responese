using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PulisherController : ControllerBase
{
    private readonly PulisherService _service;

    public PulisherController(PulisherService service)
    {
        _service = service;
    }
    
    [HttpGet("GetPublisher")]
    public List<PublisherBaseDto> GetPulisher()
    {
        return _service.GetPulisher();
    }

    [HttpGet("GetById")]
    public PublisherBaseDto? GetPulisherById(int id)
    {
        return _service.GetPulisherById(id);
    }

    [HttpPost("AddPublisher")]
    public AddPublisherDto AddPublisher(AddPublisherDto model)
    {
        return _service.AddPublisher(model);
    }
    
    [HttpPut("UpdatePublisher")]
    public async Task<IActionResult> UpdatePublisher(AddPublisherDto model)
    {
        
        var result  = await _service.UpdatePublisher(model);
        return StatusCode((int)result.StatusCode, result);
    }

    

   
    [HttpDelete("DeletePublisher")]
    public async Task<Response<bool>> DeletePublisher(int id)
    {
        return await _service.DeletePublisher(id);
    }
}