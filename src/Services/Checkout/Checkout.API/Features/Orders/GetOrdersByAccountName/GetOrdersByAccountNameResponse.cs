namespace Checkout.API.Features.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameResponse(string AccountName, List<OrderResponse> Orders);