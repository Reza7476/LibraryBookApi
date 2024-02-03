using BookLibrary.Entities.Entities;
using BookLibrary.Services.Users.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookLibrary.Services.Users;

public class UserService : IUserServicecs
{

    private readonly LibraryDbContext _db;

    public UserService(LibraryDbContext db)
    {
        _db = db;
    }

    public int Add(AddUserDto command)
    {

        var user = new User(command.Name, command.Email, command.Phone);
        _db.Users.Add(user);
        _db.SaveChanges();

        return user.Id;

    }

    public void Delete(int id)
    {
        var user = _db.Users.FirstOrDefault(_ => _.Id == id);
        if (user == null)
        {
            throw new Exception("usre not found");
        }
        _db.Users.Remove(user);
        _db.SaveChanges();
    }

    public void Edit(int id, EditUserDto command)
    {
        var user = _db.Users.FirstOrDefault(_ => _.Id == id);
        if (user == null)
        {
            throw new Exception("usre not found");
        }
        user.Edit(command.Name, command.Email, command.Phone);

        _db.SaveChanges();
    }

    public List<UserDto>? GetAll()
    {
        var users = _db.Users.Select(_ => new UserDto()
        {
            Email = _.Email,
            Name = _.Name,
            Phone = _.Phone,
            Id = _.Id
        }).ToList();
        return users;

    }

    public UserDto? GetUser(int id)
    {
        var user = _db.Users.Where(_ => _.Id == id).FirstOrDefault();
        if (user == null)
        {
            return null;
        }
        else
        {
            return new UserDto()
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Id = user.Id
            };
        }
    }
}
