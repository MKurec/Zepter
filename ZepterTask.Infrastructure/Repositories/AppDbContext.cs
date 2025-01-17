// AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using ZepterTask.Models.Domain;

public class AppDbContext : DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
   {
   }

   public DbSet<Store> Stores { get; set; }
   public DbSet<Order> Orders { get; set; }
   public DbSet<OrderLine> OrderLines { get; set; }
   public DbSet<CustomerAddress> CustomerAddresses { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      // Configure relationships
      modelBuilder.Entity<Order>()
          .HasOne(o => o.CustomerAddress)
          .WithOne(ca => ca.Order)
          .HasForeignKey<CustomerAddress>(ca => ca.OrderId);

      base.OnModelCreating(modelBuilder);
      DataSeeder.Seed(modelBuilder);
   }
}
