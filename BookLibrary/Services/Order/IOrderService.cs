using BookLibrary.Services.Order.DTOs;

namespace BookLibrary.Services.Order;

public interface IOrderService
{


    public int Add(AddOrderItemDto command);
    public void Returnbook(ReturnBookDto command);
    public void Edit(int id,EditOrderDto command);
    public void Delete(int id);


    public List<CustomerStatusDto>? CustomerStatus(int userId);
    public List<OrderDto> GetAll();
}
