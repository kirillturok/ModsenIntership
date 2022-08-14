namespace Orders.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public IEnumerable<(int ProductId, int Count)> Products { get; set; }
    public Guid Customer { get; set; }
}
