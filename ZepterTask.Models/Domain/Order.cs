namespace ZepterTask.Models.Domain;

public class Order
{
   public int Id { get; set; }
   public int StoreId { get; set; }
   public Store Store { get; set; }
   public CustomerAddress CustomerAddress { get; set; }
   public PaymentMethod PaymentMethod { get; set; }
   public ICollection<OrderLine> OrderLines { get; set; }
}