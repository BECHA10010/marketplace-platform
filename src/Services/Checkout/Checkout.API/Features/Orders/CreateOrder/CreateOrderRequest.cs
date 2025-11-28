namespace Checkout.API.Features.Orders.CreateOrder;

public record CreateOrderRequest(
    string AccountName,
    ContactDataRequest ContactData,
    AddressDataRequest AddressData,
    string PaymentMethod,
    CardDataRequest? CardData,
    List<OrderItemRequest> Items
);

public record ContactDataRequest(string FirstName, string LastName, string Email);
public record AddressDataRequest(string Street, string City);
public record CardDataRequest(string CardNumber, string Expiration, string CvvCode);
public record OrderItemRequest(string CatalogItemName, int Quantity, decimal UnitPrice);