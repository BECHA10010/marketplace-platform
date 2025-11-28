namespace Checkout.Application.Features.Orders.CreateOrder;

public record CreateOrderDto(    
    string AccountName,
    ContactDto ContactInfo,
    AddressDto DeliveryAddress,
    PaymentMethod PaymentMethod,
    CardDataDto? CardDetails,
    List<OrderItemDto> Items
);

public record ContactDto(string FirstName, string LastName, string Email);

public record AddressDto(string Street, string City);

public record CardDataDto(string CardNumber, string Expiration, string CvvCode);

public record OrderItemDto(string CatalogItemName, int Quantity, decimal UnitPrice);