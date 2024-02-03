using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Books.DTOs;

public class EditBookDto
{
    [Required]
    [MaxLength(75)]
    public string Title { get; set; }
    [Required]
    [MaxLength(75)]
    public string Category { get; set; }
    [Required]
    public int Count { get; set; }
   // [Required]
    //public int AutherId { get; set; }
    //[Required]
    //public int GenreId { get; set; }
}
