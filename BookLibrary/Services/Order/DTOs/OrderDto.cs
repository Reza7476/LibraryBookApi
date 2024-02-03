namespace BookLibrary.Services.Order.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public bool IsOpen { get;  set; }
    public int NumberOfBook { get;  set; }

    public int UserId { get; set; }
}
