namespace BookLibrary.Entities.Entities;

public class Book
{
    public Book(string title, string category, int count, int autherId, int genreId)
    {
        Guard(title, category, count);
        Title = title;
        Category = category;
        Count = count;
        AutherId = autherId;
        GenreId = genreId;

        NumberOfBorrowBook = 0;
    }

    public int Id { get; set; }
    public string Title { get; private set; }
    public string Category { get; private set; }
    public int Count { get; private set; }
    public int NumberOfBorrowBook { get;private set; }
    public int AutherId { get; private set; }
    public Auther Auther { get; set; }

    public int GenreId { get; private set; }
    public Genre Genre { get;  set; }

    public List<OrderItem> OrderItems { get; set; }



    public void SetNumberOfBorrowBook(int number)
    {
        if (number > Count)
        {
            throw new Exception("number of borrow book can not be more than number of book");
        }  

        NumberOfBorrowBook=number;
        Count = Count - number;

    }
    public void Edit(string title, string category, int count)
    {
        Guard(title, category, count);
        Title = title;
        Category = category;
    }

    public void DecreaseCount(int count)
    {
        if (count >= Count)
        {
            throw new Exception("count is more than inventory");
        }

        Count = Count - count;
    }


    public void IncreaseCount(int count)
    {
        Count = Count + count;
    }
    public void Guard(string title, string category, int count)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new Exception("title is null");
        }
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new Exception("category is null");
        }

        if (count < 0)
        {
            throw new Exception("count is less than zero");
        }
    }
}
