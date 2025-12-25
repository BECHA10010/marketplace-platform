using Checkout.API.Orders.Common.Requests;

namespace Checkout.API.Orders.CreateOrder;

public record CreateOrderRequest(
    string AccountName,
    ContactDataRequest ContactData,
    AddressDataRequest AddressData,
    string PaymentMethod,
    CardDataRequest? CardData,
    List<OrderItemRequest> Items
);