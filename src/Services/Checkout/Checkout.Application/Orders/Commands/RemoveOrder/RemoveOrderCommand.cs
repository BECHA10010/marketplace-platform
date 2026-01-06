namespace Checkout.Application.Orders.Commands.RemoveOrder;

public record RemoveOrderCommand(Guid OrderId) : ICommand<RemoveOrderResult>;