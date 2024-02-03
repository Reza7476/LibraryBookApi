using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Authers.DTOs;

public class EditAutherDto
{
    [Required]
    [MaxLength(75)]
    public string Name { get;  set; }
}
