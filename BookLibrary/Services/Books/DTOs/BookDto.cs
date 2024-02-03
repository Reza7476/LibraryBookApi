namespace BookLibrary.Services.Books.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get;  set; }
    public string Category { get; set; }
    public int Count { get; set; }

    public string  AutherName { get; set; }
    public string GenreTitle { get; set; }
}
