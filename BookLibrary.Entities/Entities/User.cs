

namespace BookLibrary.Entities.Entities;

public class User
{
    public User(string name, string email, string phone)
    {
        Guard(name, email, phone);
        Name = name;
        Email = email;
        Phone = phone;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }



    public List<Order> Order { get; set; }



    public void Edit(string name, string email, string phone)
    {
        Guard(name, email, phone);
        Name = name;
        Email = email;
        Phone = phone;
    }

    public void Guard(string name, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name)) 
        {
            throw new Exception("name is null");
        }
        if (string.IsNullOrWhiteSpace(email))
        {

            throw new Exception("email is null");
        }
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new Exception("Mobile is null");
        }
    }


}
