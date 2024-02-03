using BookLibrary.Entities.Entities;
using BookLibrary.Services.Authers.DTOs;
using System.Linq;

namespace BookLibrary.Services.Authers;

public class AutherService : IAutherService
{
    private readonly LibraryDbContext _db;

    public AutherService(LibraryDbContext db)
    {
        _db = db;
    }

    public int Add(AddAutherDto command)
    {


        var auther = _db.Authers.FirstOrDefault(_ => _.Name == command.Name);
        if (auther != null)
        {
            throw new Exception("auther exist");
        }

        Auther newAuther = new(command.Name);
        _db.Add(newAuther);
        _db.SaveChanges();
        return newAuther.Id;

    }

    public void Delete(int id)
    {
        var auther = _db.Authers.FirstOrDefault(_ => _.Id == id);
        if (auther == null)
        {
            throw new Exception("auther not found");

        }

        _db.Remove(auther);
        _db.SaveChanges();
    }

    public void Edit(int id, EditAutherDto command)
    {
        var auther = _db.Authers.FirstOrDefault(_ => _.Id == id);
        if (auther == null)
        {
            throw new Exception("auther not found");
        }
        auther.Edit(command.Name);
        _db.SaveChanges();

    }

    public List<AutherDto>? GetAll()
    {

        var authers = _db.Authers.Select(_ => new AutherDto
        {
            Id = _.Id,
            Name = _.Name,

        }).ToList();
        return authers;

    }

    public AutherDto? GetById(int id)
    {
        var auther = _db.Authers.FirstOrDefault(_ => _.Id == id);
        if (auther == null)
        {
            return null;
        }
        else
        {
            return new AutherDto()
            {
                Name = auther.Name,
                Id = auther.Id

            };
        }
    }

    public AutherDto? GetByName(string name)
    {
        var auther = _db.Authers.FirstOrDefault(_ => _.Name == name);
        if (auther == null)
        {
            return null;
        }
        else
        {
            return new AutherDto()
            {
                Name = auther.Name,
                Id = auther.Id

            };
        }
    }
}
