namespace Checkout.API.Features.Orders.CreateOrder;

public record CreateOrderRequest(
    string AccountName,
    ContactDataRequest ContactData,
    AddressDataRequest AddressData,
    string PaymentMethod,
    CardDataRequest? CardData,
    List<OrderItemRequest> Items
);