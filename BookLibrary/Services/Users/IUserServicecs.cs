using BookLibrary.Services.Users.DTOs;
using Microsoft.Identity.Client;

namespace BookLibrary.Services.Users;

public interface IUserServicecs
{

    public int Add(AddUserDto command);
    public void Edit(int id,EditUserDto command);  
    public void Delete(int id);

    public UserDto? GetUser(int id);
    public List<UserDto>? GetAll();  
}
