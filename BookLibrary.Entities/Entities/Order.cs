namespace BookLibrary.Entities.Entities;

public class Order
{
    public Order(int numberOfBook, int userId)
    {
        Guard(numberOfBook);
        NumberOfBook = numberOfBook;
        UserId = userId;
        SetOpenOrder(numberOfBook);
    }

    public int Id { get; set; }
    public bool IsOpen { get; private set; }
    public int NumberOfBook { get; private set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public List<OrderItem> OrderItems { get; set; }

    public void Guard(int numberOfBook )
    {
        if (numberOfBook < 0)
        {
            throw new Exception("number of book is less than zero");
        }
       
    }


    
    public void SetOpenOrder(int numberOfBook)
    {

        if (numberOfBook >= 4)
        {
            IsOpen = false;
        }
        else
        {
            IsOpen = true;
        }
    }
}
