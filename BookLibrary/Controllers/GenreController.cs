using BookLibrary.Services.Genres;
using BookLibrary.Services.Genres.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookLibrary.Controllers;
[Route("api/genre")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpPost("add")]
    public int Add(AddGenreDto command)
    {
        var genre = _genreService.Add(command);
        return genre;
    }
    [HttpPatch("edit/{id}")]
    public void Edit([FromRoute] int id, [FromBody] EditGenreDto command)
    {
        _genreService.Edit(id, command);
    }

    [HttpDelete("delete/{id}")]
    public void Delete([FromRoute] int id)
    {

        _genreService.Delete(id);
    }
    [HttpGet("get-all")]
    public List<GenreDto>? GetAll()
    {


        var genres = _genreService.GetAll();
        return genres;
    }

    [HttpGet("get-by-Id/{id}")]
    public GenreDto? GetById([FromRoute] int id)
    {
        var genre = _genreService.GetById(id);
        return genre;
    }

    [HttpGet("get-by-title/{title}")]
    public GenreDto? GetByTitle([FromRoute]string title)
    {
        var genre=_genreService.GetByName(title);
        return genre;
    }

}
