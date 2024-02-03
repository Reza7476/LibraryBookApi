using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Genres.DTOs;

public class AddGenreDto
{
    [Required]
    [MaxLength(75)]
    public string Title { get; set; }
}
