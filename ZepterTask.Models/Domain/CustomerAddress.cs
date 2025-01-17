namespace ZepterTask.Models.Domain;

public class CustomerAddress
{
   public int Id { get; set; }
   public string Street { get; set; }
   public string City { get; set; } // Includes cities with the letter 'w'
   public string PostalCode { get; set; }
   public int OrderId { get; set; }
   public Order Order { get; set; }
}