using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Genres.DTOs;

public class EditGenreDto
{
    [Required]
    [MaxLength(75)]
    public string Title { get; set; }
}
