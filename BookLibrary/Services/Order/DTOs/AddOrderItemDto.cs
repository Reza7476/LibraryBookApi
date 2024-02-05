using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Order.DTOs;

public class AddOrderItemDto
{
    [Required]
    public string  UserName { get; set; }
    
    [Required]
    public string BookName { get; set; }
   
    [Required]
    public int NumberOfBook { get; set; }

    [Required]
    public DateTime DaysForRent { get; set; }
}
