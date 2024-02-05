using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Books.DTOs;

public class CreateBookDto
{
    public string Title { get; set; }
    public string Category { get; set; }
    public int Count { get; set; }
    public int AutherId { get; set; }
    public int GenreId { get; set; }

}
