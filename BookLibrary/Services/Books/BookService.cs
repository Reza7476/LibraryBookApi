using BookLibrary.Entities.Entities;
using BookLibrary.Services.Books.DTOs;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookLibrary.Services.Books;

public class BookService : IBookServicecs
{

    private readonly LibraryDbContext _db;

    public BookService(LibraryDbContext db)
    {
        _db = db;
    }

    public int Add(AddBookDto command)
    {
        var book = new Book(command.Title, command.Category, command.Count, command.AutherId, command.GenreId);

        _db.Books.Add(book);
        _db.SaveChanges();
        return book.Id;
    }

    public void Delete(int id)
    {
        var book = _db.Books.FirstOrDefault(_ => _.Id == id);
        if (book == null)
        {
            throw new Exception("book not found");
        }

        _db.Books.Remove(book);
        _db.SaveChanges();

    }

    public void Edit(int id, EditBookDto command)
    {
        var book = _db.Books.FirstOrDefault(_ => _.Id == id);
        if (book == null)
        {
            throw new Exception("book not found");
        }

        book.Edit(command.Title, command.Category, command.Count);
        _db.SaveChanges();

    }

    public BookDto? GetById(int id)
    {
        var book = _db.Books.Where(_ => _.Id == id)
            .Include(_ => _.Genre)
            .Include(_ => _.Auther)
            .Select(_ => new BookDto()
            {
                Title = _.Title,
                AutherName = _.Auther.Name,
                Category = _.Category,
                GenreTitle = _.Genre.Title,
                Count = _.Count,
                Id = _.Id

            }).FirstOrDefault();

        return book;



    }




    public List<BookDto>? GetAll()
    {
        var book = _db.Books
           .Include(_ => _.Genre)
           .Include(_ => _.Auther)
           .Select(_ => new BookDto()
           {
               Title = _.Title,
               AutherName = _.Auther.Name,
               Category = _.Category,
               GenreTitle = _.Genre.Title,
               Count = _.Count,
               Id = _.Id

           }).ToList();
        return book;
    }

    public BookDto? GetBookByFilter(FilterBookDto command)
    {

        var result = _db.Books.OrderByDescending(_ => _.Id).AsQueryable();
        if (!string.IsNullOrWhiteSpace(command.GenreTitle))
        {
            
        }
        if (!string.IsNullOrWhiteSpace(command.BookName))
        {
            result=result.Where(_=>_.Title.Contains(command.BookName));     
        }

        if (!string.IsNullOrWhiteSpace(command.AutherName))
        {

        }

        if (!string.IsNullOrWhiteSpace(command.Categotry))
        {
            result = result.Where(_ => _.Title.Contains(command.Categotry));
        }


        var model = result.Select(_ => new BookDto()
        {
            Title = _.Title,
            AutherName = _.Auther.Name,
            Category = _.Category,
            Count = _.Count,
            GenreTitle = _.Genre.Title,
            Id = _.Id
        }).FirstOrDefault();

        //var book = _db.Books
        //       .Where(_ => _.Title
        //       .Contains(command.BookName) ||
        //       _.Category.Contains(command.Categotry))
        //       .Include(x=>x.Genre)
        //       .Include(x=>x.Auther)
        //       .Select(_ => new BookDto()
        //       {
        //           Title = _.Title,
        //           AutherName = _.Auther.Name,
        //           Category = _.Category,
        //           Count = _.Count,
        //           GenreTitle = _.Genre.Title,
        //           Id = _.Id
        //       }).FirstOrDefault();

        return model;
    }

    public List<BookDto>? GetBooksByGenre(string genre)
    {
        var books = (from book in _db.Books
                     join genres in _db.Genres
                     on book.GenreId equals genres.Id
                     select new BookDto()
                     {
                         AutherName = book.Auther.Name,
                         Category = book.Category,
                         Count = book.Count,
                         Id = book.Id,
                         GenreTitle = book.Genre.Title,
                         Title = book.Title
                     }).ToList();


        return books;


    }
}
