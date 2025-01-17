using ZepterTask.Models.Domain;

namespace ZepterTask.Models.DTOs;

public class PaymentSumaryDTO
{
   public PaymentMethod PaymentMethod { get; set; }
   public int OrdersCount { get; set; }
   public decimal TotalGrossPrice { get; set; }

}