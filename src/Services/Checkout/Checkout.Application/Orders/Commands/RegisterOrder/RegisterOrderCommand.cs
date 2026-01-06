namespace Checkout.Application.Orders.Commands.RegisterOrder;

public record RegisterOrderCommand( 
    Guid CorrelationId,
    string AccountName,
    CustomerContactDto Contact,
    CustomerAddressDto Address,
    string PaymentMethod,
    CardDetailsDto? Card,
    IReadOnlyList<OrderItemDto> Items
) : ICommand;