using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Order.DTOs;

public class AddOrderDto
{
    [Required]
    public bool IsOpen { get; set; }
    [Required]
    public int NumberOfBook { get; set; }
    [Required]
    public int UserId { get; set; }
}
