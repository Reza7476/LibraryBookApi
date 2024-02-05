namespace BookLibrary.Services.Books.DTOs;

public class BookDto
{
    public string Title { get;  set; }
    public string Category { get; set; }
    public int NumberOfBorrowBook { get; set; }
    public int numberOfNotBorrowBook { get; set; }
    public string  AutherName { get; set; }
    public string GenreTitle { get; set; }
    public int Capacity { get; set; }
    
    public int Id { get; set; }
}
