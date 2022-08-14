namespace Orders.Domain.Models;

public class Order : Entity
{
    public string Address { get; set; }
    public int Product { get; set; }
    public Guid Customer { get; set; }
}
