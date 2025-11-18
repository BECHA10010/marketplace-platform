namespace Checkout.API.Endpoints.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameResponse(IEnumerable<OrderDto> Orders);