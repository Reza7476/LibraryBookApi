namespace BookLibrary.Entities.Entities;

public class Genre
{
    public Genre(string title)
    {
        Title = title;
    }

    public int Id { get; set; }
    public string Title { get; private set; }


    public List<Book> Books { get; set; }




    public void Edit(string title)
    {
        Guard(title);
        Title= title;   
    }
    public void Guard(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new Exception("name is null");
        }
        Title = title;
    }

}
