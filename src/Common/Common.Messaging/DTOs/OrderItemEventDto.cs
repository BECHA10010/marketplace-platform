namespace Common.Messaging.DTOs;

public class OrderItemEventDto
{
    public string Title { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}