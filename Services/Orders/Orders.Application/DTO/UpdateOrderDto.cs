namespace Orders.Application.DTO;

public class UpdateOrderDto
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public int Products { get; set; }
    public Guid Customer { get; set; }
}
