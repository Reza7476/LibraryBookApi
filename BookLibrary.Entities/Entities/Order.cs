namespace BookLibrary.Entities.Entities;

public class Order
{
    public Order( int userId)
    {
       
      
        UserId = userId;
        OrderDate = DateTime.Now;
    }

    public int Id { get; set; }
  
    public int NumberOfNotReturnedBook { get; private set; }
    public DateTime  OrderDate { get; private set; }
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
    
    public void IncreaseNmberOfNotReturnedBook(int number)
    {
        NumberOfNotReturnedBook = NumberOfNotReturnedBook + number;
    }

    public void DecreaseNumberOfNotReturnedBook(int number)
    {
        NumberOfNotReturnedBook = NumberOfNotReturnedBook - number;
    }
    
}
