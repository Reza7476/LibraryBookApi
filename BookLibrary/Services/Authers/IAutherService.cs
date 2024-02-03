using BookLibrary.Services.Authers.DTOs;

namespace BookLibrary.Services.Authers;

public interface IAutherService
{


    public int Add(AddAutherDto command);
    public void Edit(int id,EditAutherDto command);
    public void Delete(int id);

    public List<AutherDto>? GetAll();
    public AutherDto? GetById(int id);

    public AutherDto? GetByName(string name);

}
