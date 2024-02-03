using BookLibrary.Services.Genres.DTOs;

namespace BookLibrary.Services.Genres;

public interface IGenreService
{
    public int Add(AddGenreDto command);

    public void Edit(int id,EditGenreDto command);

    public void Delete(int id);

    public List<GenreDto>? GetAll();

    public GenreDto? GetById(int id); 
    
    public GenreDto? GetByName(string title);
}
