namespace BookLibrary.Entities.Entities;

public class OrderItem
{
    public OrderItem(int numberOfBook, int bookId, int orderId)
    {
        NumberOfBook = numberOfBook;
        BorrowDate = DateTime.Now;
        BookId = bookId;
        OrderId = orderId;
        
    }

    public int Id { get; set; }
    public int NumberOfBook { get; private set; }
    public DateTime BorrowDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    public int BookId { get; private set; }
    public int OrderId { get; private set; }

    public Order Order { get; set; }

    public Book Book { get; set; }



    
    public void SetReturnDate(int days)
    {
        ReturnDate = BorrowDate.AddDays(days);
    }
}
