namespace Products.Application.DTO;

public class CreateOrderDto
{
    public string Address { get; set; }
    public int Products { get; set; }
    public Guid Customer { get; set; }
}
