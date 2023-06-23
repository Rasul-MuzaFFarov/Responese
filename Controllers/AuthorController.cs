using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _service;

    public AuthorController(AuthorService service)
    {
        _service = service;
    }

    [HttpGet("GetAuthor")]
    public List<AuthorBaseDto> GetAuhtor()
    {
        return _service.GetAuthor();
    }

    [HttpGet("GetById")]
    public AuthorBaseDto GetAuthorById(int id)
    {
        return _service.GetAuthorById(id);
    }

    [HttpPost("AddAuthor")]
    public AddAuthorDto AddAuthor(AddAuthorDto model)
    {
        return _service.AddAuthor(model);
    }

    // [HttpPut("UpdateAuthor")]
    // public AddAuthorDto UpdateAuthor(AddAuthorDto model)
    // {
    //     return _service.UpdateAuthor(model);
    // }
    [HttpPut("UpdateAuthor")]
    public async Task<IActionResult> UpdateAuthor(AddAuthorDto model)
    {
        
        var result  = await _service.UpdateAuthor(model);
        return StatusCode((int)result.StatusCode, result);
    }

    

    [HttpDelete("DeleteAuthor")]
    public async Task<Response<bool>> DeleteAuthor(int id)
    {
        return await _service.DeleteAuthor(id);
    }
}