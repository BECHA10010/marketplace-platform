namespace Checkout.API.Features.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameResponse(IEnumerable<OrderDto> Orders);