using ZepterTask.Models.Domain;

namespace ZepterTask.Models.DTOs;

public class OrderSummaryDto
{
   public int OrderId { get; set; }
   public int StoreId { get; set; }
   public PaymentMethod PaymentMethod { get; set; }
   public decimal TotalNetPrice { get; set; }
}