using Microsoft.AspNetCore.Mvc;
using ZepterTask.Infrastructure.Services;

namespace ZepterTask2.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
   private readonly OrderService _orderService;

   public OrdersController(OrderService orderService)
   {
      _orderService = orderService;
   }


   [HttpGet("even-stores-with-w")]
   public async Task<IActionResult> GetOrdersFromEvenStoresWithW()
   {
      var orders = await _orderService.GetOrdersFromEvenStoresWithWAsync();
      return Ok(orders);
   }
}
