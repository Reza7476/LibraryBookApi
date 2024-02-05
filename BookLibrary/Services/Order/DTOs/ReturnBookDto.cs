using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace BookLibrary.Services.Order.DTOs;

public class ReturnBookDto
{
    [Required]
    public string  UserName { get; set; }
    [Required]
    public string  BookName { get; set; }
}
