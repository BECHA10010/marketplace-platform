namespace Checkout.Application.Orders.Queries.GetOrdersByAccountName;

public record GetOrdersByAccountNameResult(IEnumerable<Order> Orders);