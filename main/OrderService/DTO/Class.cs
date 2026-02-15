namespace OrderService.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
}

