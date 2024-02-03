using BookLibrary.Entities.Entities;
using BookLibrary.Services.Genres.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace BookLibrary.Services.Genres;

public class GenreService : IGenreService
{
    private readonly LibraryDbContext _db;

    public GenreService(LibraryDbContext db)
    {
        _db = db;
    }

    public int Add(AddGenreDto command)
    {
        var genre = _db.Genres.FirstOrDefault(_ => _.Title == command.Title);

        if (genre != null)
        {

            throw new Exception("Genre is exist");
        }

        Genre newGenre = new Genre(command.Title);
        _db.Genres.Add(newGenre);
        _db.SaveChanges();
        return newGenre.Id;
    }

    public void Delete(int id)
    {


        var genre = _db.Genres.FirstOrDefault(_ => _.Id == id);
        if (genre == null)
        {
        throw new Exception("genre not found");
        }
            _db.Genres.Remove(genre);
            _db.SaveChanges();



    }

    public void Edit(int id, EditGenreDto command)
    {
        var genre = _db.Genres.FirstOrDefault(_ => _.Id == id);
        if (genre == null)
        {
        throw new Exception("genre not found");
        }
            genre.Edit(command.Title);
            _db.SaveChanges();

    }

    public List<GenreDto>? GetAll()
    {
        var genres = _db.Genres.Select(_ => new GenreDto
        {
            Id = _.Id,
            Title = _.Title,
        }).ToList();

        return genres;
    }

    public GenreDto? GetById(int id)
    {


        var genre = _db.Genres.FirstOrDefault(_ => _.Id == id);
        if (genre == null)
        {
            return null;
        }
        else
        {
            return new GenreDto
            {
                Id = genre.Id,
                Title = genre.Title
            };


        }
    }

    public GenreDto? GetByName(string title)
    {
        var genre = _db.Genres.FirstOrDefault(_ => _.Title == title);
        if (genre == null)
        {
            return null;
        }
        else
        {
            return new GenreDto
            {
                Id = genre.Id,
                Title = genre.Title
            };


        }

    }
}
