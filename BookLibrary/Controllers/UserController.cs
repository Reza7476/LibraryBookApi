using BookLibrary.Services.Users;
using BookLibrary.Services.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BookLibrary.Controllers;
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserServicecs _userService;

    public UserController(IUserServicecs userService)
    {
        _userService = userService;
    }
    [HttpPost("add")]
    public int Add(AddUserDto command)
    {
        var user = _userService.Add(command);
        return user;
    }
    [HttpPatch("edit/{id}")]
    public void Edit([FromRoute] int id, EditUserDto command)
    {

        _userService.Edit(id, command);
    }

    [HttpDelete("delete/{id}")]
    public void Delete([FromRoute] int id)
    {
        _userService.Delete(id);
    }

    [HttpGet("get-all")]
    public List<UserDto>? GetAll()
    {
        return _userService.GetAll();
    }


    [HttpGet("get-by-id/{id}")]
    public UserDto? GetById([FromRoute]int id)
    {
        return _userService.GetUser(id);
    }





}
