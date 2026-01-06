namespace Common.Messaging.Events;

public class OrderSubmittedIntegrationEvent : BaseIntegrationEvent
{
    public string AccountName { get; init; } = default!;
    
    public CustomerContactEventDto Contact { get; init; } = default!;
    public CustomerAddressEventDto Address { get; init; } = default!;
    public PaymentDetailsEventDto Payment { get; init; } = default!;
    public IReadOnlyList<OrderItemEventDto> Items { get; init; } = [];
}