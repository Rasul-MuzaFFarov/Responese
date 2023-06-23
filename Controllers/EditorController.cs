using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EditorController : ControllerBase
{
    private readonly EditorService _service;

    public EditorController(EditorService service)
    {
        _service = service;
    }
    
    [HttpGet("GetEditor")]
    public List<GetEditorDto> GetEditor()
    {
        return _service.GetEditor();
    }

    [HttpGet("GetById")]
    public GetEditorDto GetEditorById(int id)
    {
        return _service.GetEditorById(id);
    }

    [HttpPost("AddEditor")]
    public AddEditorDto AddEditor(AddEditorDto model)
    {
        return _service.AddEditor(model);
    }

    [HttpPut("UpdateEditor")]
    public async Task<IActionResult> UpdateEditor(AddEditorDto model)
    {
        
        var result  = await _service.UpdateEditor(model);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("DeleteEditor")]
    public async Task<Response<bool>> Deleteeditor(int id)
    {
        return await _service.DeleteEditor(id);
    }
}