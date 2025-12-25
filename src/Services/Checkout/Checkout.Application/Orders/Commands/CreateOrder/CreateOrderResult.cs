namespace Checkout.Application.Orders.Commands.CreateOrder;

public record CreateOrderResult(Guid OrderId, string Message);