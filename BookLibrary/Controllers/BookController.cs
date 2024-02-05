using BookLibrary.Services.Authers;
using BookLibrary.Services.Books;
using BookLibrary.Services.Books.DTOs;
using BookLibrary.Services.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers;
[Route("api/book")]
[ApiController]
public class BookController : ControllerBase
{

    private readonly IBookServicecs _bookService;

    private readonly IAutherService _autherService;
    private readonly IGenreService _genreService;


    public BookController(IBookServicecs bookService, IAutherService autherService, IGenreService genreService)
    {
        _bookService = bookService;
        _autherService = autherService;
        _genreService = genreService;
    }




    [HttpPost("add")]
    public int Add(AddBookDto command)
    {


        var genre = _genreService.GetByName(command.GenreTitle);
        var auther = _autherService.GetByName(command.AutherName)
;


        if (genre == null && auther == null)
        {
            throw new Exception("auther is not registered");
        }
        else
        {
            CreateBookDto dto = new CreateBookDto()
            {
                Title = command.Title,
                Count = command.Count,
                GenreId = genre.Id,
                AutherId = auther.Id,
                Category = command.Category
            };
          
        var book = _bookService.Add(dto);
            return book;


        }



    }
    [HttpPatch("edit/{id}")]
    public void Edit([FromRoute]int id,EditBookDto command)
    {
        _bookService.Edit(id, command);
    }


    [HttpGet("get-all")]
    public List<BookDto>? GetAll()
    {
        var books=_bookService.GetAll();
        return books;
    }

    [HttpGet("get-by-id/{id}")]
    public BookDto? GetById([FromRoute]int id)
    {
        var book = _bookService.GetById(id);
        return book;
    }
    [HttpGet("filter")]
    public BookDto? FilterBook([FromQuery]FilterBookDto command)
    {
        var book = _bookService.GetBookByFilter(command);
        return book;
    }

    [HttpGet("get-by-genre/{genre}")]
    public List<BookDto>? GetBooksByGenre(string genre)
    {
        var books = _bookService.GetBooksByGenre(genre);
        return books;
    }
}
