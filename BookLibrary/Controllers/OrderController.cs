using BookLibrary.Services.Order;
using BookLibrary.Services.Order.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers;
[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{


    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }



    [HttpPost("add")]
    public int Add(AddOrderItemDto command)
    {
        return _orderService.Add(command);
    }



    [HttpPut("returnBook")]
    public void ReturnBook(ReturnBookDto command)
    {
        _orderService.Returnbook(command);
    }

    [HttpGet("customerStatus/{id}")]
    public List<CustomerStatusDto>? CustomrStatus(int id)
    {
        return _orderService.CustomerStatus(id);
    }
}
