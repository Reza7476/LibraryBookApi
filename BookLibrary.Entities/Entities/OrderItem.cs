namespace BookLibrary.Entities.Entities;

public class OrderItem
{
    public OrderItem(int numberOfBook, int bookId, int orderId, DateTime returnDate)
    {
        NumberOfBook = numberOfBook;

        BookId = bookId;
        OrderId = orderId;
        ReturnDate = returnDate;
        ReturnStatus = false;
        OrderDate = DateTime.Now;
   
    }

    public int Id { get; set; }
    public int NumberOfBook { get; private set; }
    
    public DateTime ReturnDate { get; private set; }
    public DateTime OrderDate { get; private set; }

 
    public int BookId { get; private set; }
    public int OrderId { get; private set; }
    public bool ReturnStatus { get; private set; }
    public Order Order { get; set; }

    public Book Book { get; set; }

    public void ChangeReturnStatus()
    {
        ReturnStatus = true;
    }



}
