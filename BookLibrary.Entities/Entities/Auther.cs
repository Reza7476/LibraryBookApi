namespace BookLibrary.Entities.Entities;

public class Auther
{
    public Auther(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }

    public List<Book> Books { get; set; }



    public void Guard(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("name is nul");
        }
    }


    public void Edit(string name)
    {
        Guard(name);
        Name = name;
    }


}
