namespace ZepterTask.Models.Domain;

public class OrderLine
{
   public int Id { get; set; }
   public string ProductCode { get; set; }
   public decimal NetPrice { get; set; }
   public decimal GrossPrice { get; set; }
   public int Quantity { get; set; }
   public int OrderId { get; set; }
   public Order Order { get; set; }
}