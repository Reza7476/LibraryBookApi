using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Order.DTOs;

public class EditOrderDto
{
    [Required]
    public bool IsOpen { get; set; }
    [Required]
    public int NumberOfBook { get; set; }
    [Required]
    public int UserId { get; set; }
}
