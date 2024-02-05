using BookLibrary.Entities.Entities;
using BookLibrary.EntityConfig.ItemOrders;
using BookLibrary.Services.Order.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Order;

public class OrderService : IOrderService
{

    private readonly LibraryDbContext _db;

    public OrderService(LibraryDbContext db)
    {
        _db = db;
    }

    public int Add(AddOrderItemDto command)
    {

        var user = _db.Users.FirstOrDefault(_ => _.Name == command.UserName);

        if (user == null)
        {
            throw new Exception("user not registerd");
        }

        var book = _db.Books.FirstOrDefault(_ => _.Title == command.BookName);
        if (book == null)
        {
            throw new Exception("book not found");
        }
        if (command.NumberOfBook > 4)
        {
            throw new Exception("The number of requests exceeds the limit ");
        }
        if (command.NumberOfBook > book.RestOfBook)
        {
            throw new Exception("number of book is more than inventory");
        }
        var checkOrder = _db.Orders.FirstOrDefault(_ => _.UserId == user.Id && _.NumberOfNotReturnedBook > 0);
        if (checkOrder != null)
        {

            if (checkOrder.NumberOfNotReturnedBook > 4)
            {
                throw new Exception("The number of requests exceeds the limit ");
            }
            var check = _db.Orders.Where(_ => _.UserId == user.Id).Select(x => x.NumberOfNotReturnedBook).Sum();
            if (command.NumberOfBook + check > 4)
            {
                throw new Exception("The number of requests exceeds the limit ");
            }
            OrderItem orderItemForCustomer = new OrderItem(command.NumberOfBook, book.Id, checkOrder.Id, command.DaysForRent);
            _db.OrderItems.Add(orderItemForCustomer);
            _db.SaveChanges();
            book.IncreaseNumberOfBorrowBook(command.NumberOfBook);
            checkOrder.IncreaseNmberOfNotReturnedBook(command.NumberOfBook);
            _db.SaveChanges();
            return checkOrder.Id;

        }
        else
        {

            BookLibrary.Entities.Entities.Order order = new(user.Id);
            _db.Orders.Add(order);
            _db.SaveChanges();
            OrderItem orderItem = new OrderItem(command.NumberOfBook, book.Id, order.Id, command.DaysForRent);
            _db.OrderItems.Add(orderItem);
            _db.SaveChanges();

            book.IncreaseNumberOfBorrowBook(command.NumberOfBook);
            order.IncreaseNmberOfNotReturnedBook(command.NumberOfBook);
            _db.SaveChanges();
            return order.Id;
        }
    }

    public List<CustomerStatusDto>? CustomerStatus(int userId)
    {

        var orders = _db.Orders.Where(_ => _.UserId == userId)
            .Include(_ => _.OrderItems)
            .ThenInclude(_ => _.Book)
            .ToList();


        if (orders.Count > 0)
        {
          List<CustomerStatusDto>  customerStatus=  new();

            foreach (var order in orders)
            {
                foreach(var orderItem  in order.OrderItems)
                {
                    CustomerStatusDto customer = new CustomerStatusDto()
                    {
                        BookName = orderItem.Book.Title,
                        NumberOfBook = orderItem.NumberOfBook,
                        ReturnStatus = orderItem.ReturnStatus
                    };
                    customerStatus.Add(customer);
                }
            }
            return customerStatus;
        }

        return null;


    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Edit(int id, EditOrderDto command)
    {
        throw new NotImplementedException();
    }

    public List<OrderDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Returnbook(ReturnBookDto command)
    {
        var book = _db.Books.FirstOrDefault(_ => _.Title == command.BookName);
        var user = _db.Users.FirstOrDefault(_ => _.Name == command.UserName);
        if (book != null && user != null)
        {
            var order = _db.Orders.FirstOrDefault(_ => _.UserId == user.Id && _.NumberOfNotReturnedBook > 0);
            if (order != null)
            {
                var orderItem = _db.OrderItems.FirstOrDefault(_ => _.OrderId == order.Id && _.BookId == book.Id && _.ReturnStatus == false);
                if (orderItem != null)
                {
                    orderItem.ChangeReturnStatus();
                    order.DecreaseNumberOfNotReturnedBook(orderItem.NumberOfBook);
                    book.DecreaseNumberOfBorrowBook(orderItem.NumberOfBook);
                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception("order not found");

                }
            }
            else
            {
                throw new Exception("this user not have any order");
            }
        }
        else
        {
            throw new Exception("Error");
        }
    }
}
