using Microsoft.EntityFrameworkCore;
using ZepterTask.Models.Domain;

public static class DataSeeder
{
   public static void Seed(ModelBuilder modelBuilder)
   {
      var random = new Random();
      var citiesWithW = new[] { "Warsaw", "Wroclaw", "Gdansk", "Krakow", "Poznan" };
      var citiesWithoutW = new[] { "Lodz", "Szczecin", "Bydgoszcz", "Lublin", "Katowice" };

      // Seed Stores
      var stores = Enumerable.Range(1, 10)
          .Select(i => new Store
          {
             Id = i,
             Name = $"Sklep {i}"
          }).ToList();

      // Seed Orders
      var orders = Enumerable.Range(1, 30).Select(i => new Order
      {
         Id = i,
         StoreId = (i % 10) + 1,
         PaymentMethod = (PaymentMethod)(i % 3),
      }).ToList();

      // Seed CustomerAddresses
      var customerAddresses = Enumerable.Range(1, 30).Select(i => new CustomerAddress
      {
         Id = i,
         Street = $"Street {i}",
         City = i % 2 == 0 ? citiesWithW[random.Next(citiesWithW.Length)] : citiesWithoutW[random.Next(citiesWithoutW.Length)],
         PostalCode = $"00-0{i}",
         OrderId = i
      }).ToList();

      // Seed OrderLines
      var orderLines = Enumerable.Range(1, 30).Select(i => new OrderLine
      {
         Id = i,
         ProductCode = $"P{i}",
         NetPrice = 130 + i,
         GrossPrice = 140 + i,
         Quantity = i,
         OrderId = i
      }).ToList();

      modelBuilder.Entity<Store>().HasData(stores);
      modelBuilder.Entity<Order>().HasData(orders);
      modelBuilder.Entity<CustomerAddress>().HasData(customerAddresses);
      modelBuilder.Entity<OrderLine>().HasData(orderLines);
   }
}
