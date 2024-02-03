using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Users.DTOs;

public class AddUserDto
{
    [Required]
    [MaxLength(75)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    [Required]
    [MaxLength(12)]
    public string Phone { get; set; }
}
