using BookLibrary.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Services.Books.DTOs;

public class AddBookDto
{
    [Required]
    [MaxLength(75)]
    public string Title { get; set; }
    [Required]
    [MaxLength(75)]
    public string Category { get; set; }
    [Required]
    public int Count { get; set; }
    [Required]
    public string  AutherName { get; set; }
    [Required]
    public string GenreTitle { get; set; }

    //public Auther Auther { get; set; }
    //public Genre Genre { get; set; }

    //public string  AutherName { get; set; }
    //public string GenreTitle { get; set; }


}
