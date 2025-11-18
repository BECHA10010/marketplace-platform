namespace Checkout.Application.Queries.Orders.GetOrdersByAccountName;

public record GetOrdersByAccountNameResult(IEnumerable<Order> Orders);