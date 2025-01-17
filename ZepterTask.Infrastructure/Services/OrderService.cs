using Microsoft.EntityFrameworkCore;
using ZepterTask.Infrastructure.Repositories;
using ZepterTask.Models.Domain;
using ZepterTask.Models.DTOs;

namespace ZepterTask.Infrastructure.Services;

public class OrderService
{
   private readonly IGenericRepository<Order> _orderRepository;
   private readonly AppDbContext _context;

   public OrderService(IGenericRepository<Order> orderRepository, AppDbContext context)
   {
      _orderRepository = orderRepository;
      _context = context;
   }

   public async Task<Order?> GetOrderByIdAsync(int id)
   {
      return await _orderRepository.GetAsync(o => o.Id == id);
   }

   public async Task<IEnumerable<OrderSummaryDto>> GetOrdersFromEvenStoresWithWAsync()
   {
      var query = @"
               SELECT o.Id, o.StoreId, o.PaymentMethod, SUM(ol.NetPrice) AS TotalNetPrice
               FROM Orders o
               JOIN CustomerAddresses ca ON o.Id = ca.OrderId
               JOIN OrderLines ol ON o.Id = ol.OrderId
               WHERE o.StoreId % 2 = 0 AND ca.City LIKE '%w%'
               GROUP BY o.Id, o.StoreId, o.PaymentMethod";

      var orders = await _context.Orders
          .FromSqlRaw(query)
          .Select(o => new OrderSummaryDto
          {
             OrderId = o.Id,
             StoreId = o.StoreId,
             PaymentMethod = o.PaymentMethod,
             TotalNetPrice = _context.OrderLines
                  .Where(ol => ol.OrderId == o.Id)
                  .Sum(ol => ol.NetPrice)
          })
          .ToListAsync();

      return orders;
   }

   //Podsumowanie ilości zamówień oraz ich wartości brutto w podziale na poszczególne typy płatności i uwzględniając tylko zamówienia warte nie mniej niż 150zł. Użycie EF i LINQ.

   public async Task<List<PaymentSumaryDTO>> GetPaymentSummaryAsync()
   {
      return await _context.Orders
          .Where(o => o.OrderLines.Sum(ol => ol.GrossPrice) >= 150)
          .GroupBy(o => o.PaymentMethod)
          .Select(g => new PaymentSumaryDTO
          {
             PaymentMethod = g.Key,
             OrdersCount = g.Count(),
             TotalGrossPrice = g.Sum(o => o.OrderLines.Sum(ol => ol.GrossPrice))
          })
          .ToListAsync();
   }


}