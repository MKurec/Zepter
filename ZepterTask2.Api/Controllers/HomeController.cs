using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using ZepterTask.Infrastructure.Services;
using ZepterTask.Models.DTOs;
using ZepterTask2.Api.Models;

namespace ZepterTask2.Api.Controllers
{
   public class HomeController : Controller
   {
      private readonly OrderService _orderService;

      public HomeController(OrderService orderService)
      {
         _orderService = orderService;
      }

      public IActionResult Index()
      {
         return View();
      }

      public async Task<IActionResult> DataFromWebService()
      {
         var url = Url.Action("GetOrdersFromEvenStoresWithW", "Orders");
         if (url != null)
         {
            var client = new HttpClient
            {
               BaseAddress = new Uri($"{Request.Scheme}://{Request.Host}")
            };
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();
               var options = new JsonSerializerOptions
               {
                  PropertyNameCaseInsensitive = true
               };
               var orders = JsonSerializer.Deserialize<List<OrderSummaryDto>>(content, options);
               return View(orders);
            }
         }
         var list = new List<OrderSummaryDto>();

         return View(list);
      }

      public async Task<IActionResult> DataFromEntityFramework()
      {
         var summary = await _orderService.GetPaymentSummaryAsync();
         return View(summary);
      }
   }
}
