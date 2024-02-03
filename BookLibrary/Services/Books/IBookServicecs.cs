using BookLibrary.Services.Books.DTOs;

namespace BookLibrary.Services.Books;

public interface IBookServicecs
{
    public int Add(AddBookDto command);

    public void Edit(int id, EditBookDto command);

    public void Delete(int id);

    public List<BookDto>? GetAll();

    public BookDto? GetById(int id);
    public BookDto? GetBookByFilter(FilterBookDto command);

    public List<BookDto>? GetBooksByGenre(string genre);  
}
