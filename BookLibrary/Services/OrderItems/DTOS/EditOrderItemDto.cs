using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.OrderItems.DTOS;

public class EditOrderItemDto
{
    [Required]
    public int NumberOfBook { get; set; }
    
    public DateTime BorrowDate { get; set; }

    public DateTime ReturnDate { get; set; }
    [Required]
    public int BookId { get; set; }
    [Required]
    public int OrderId { get; set; }
}
