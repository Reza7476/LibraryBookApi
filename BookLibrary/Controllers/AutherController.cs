using BookLibrary.Services.Authers;
using BookLibrary.Services.Authers.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers;
[Route("api/auther")]
[ApiController]
public class AutherController : ControllerBase
{

    private readonly IAutherService _autherService;

    public AutherController(IAutherService autherService)
    {
        _autherService = autherService;
    }
    [HttpPost("add")]
    public int Add(AddAutherDto command)
    {
        var auther = _autherService.Add(command);
        return auther;
    }
    [HttpPatch("edit/{id}")]
    public void Edit([FromRoute] int id, [FromBody] EditAutherDto command)
    {
        _autherService.Edit(id, command);
    }
    [HttpDelete("delete/{id}")]
    public void Delete([FromRoute] int id)
    {
        _autherService.Delete(id);
    }

    [HttpGet("get-all")]
    public List<AutherDto>? GetAll()
    {
        var authers = _autherService.GetAll();
        return authers;
    }

    [HttpGet("get-by-Id/{id}")]
    public AutherDto? GetById([FromRoute]int id)
    {
        var auther = _autherService.GetById(id);
        return auther;
    }
    [HttpGet("get-by-name/{name}")]
    public AutherDto? GetById([FromRoute]string name)
    {
        var auther = _autherService.GetByName(name);
        return auther;
    }
}
