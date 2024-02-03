namespace BookLibrary.Services.OrderItems.DTOS;

public class OrderItemDto
{
    public int Id { get; set; }

    
    public int NumberOfBook { get;  set; }
    
    public DateTime BorrowDate { get;  set; }
    
    public DateTime ReturnDate { get; set; }
    
    public int BookId { get; set; }
    
    public int OrderId { get; set; }
}
