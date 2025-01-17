namespace ZepterTask.Models.Domain;

public class Store
{
   public int Id { get; set; } // Store numbers from 1 to 10
   public string Name { get; set; } // "Sklep 1", "Sklep 2", etc.
   public ICollection<Order> Orders { get; set; }
}