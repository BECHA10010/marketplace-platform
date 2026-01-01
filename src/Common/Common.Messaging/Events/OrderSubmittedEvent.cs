namespace Common.Messaging.Events;

public class OrderSubmittedEvent : BaseIntegrationEvent
{
    public Guid OrderId { get; set; }
    public string AccountName { get; set; } = default!;
    public decimal TotalAmount { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    
    public string Street { get; set; } = default!;
    public string City { get; set; } = default!;

    public int PaymentMethod { get; set; }
    public string? CardNumber { get; set; }
    public string? Expiration { get; set; }
    public string? CvvCode { get; set; }

    public List<OrderItemEventDto> Items { get; set; } = [];
}