namespace Orders.Application.DTO;

public class CreateOrderDto
{
    public string Address { get; set; }
    public IEnumerable<(int ProductId, int Count)> Products { get; set; }
    public Guid Customer { get; set; }
}
