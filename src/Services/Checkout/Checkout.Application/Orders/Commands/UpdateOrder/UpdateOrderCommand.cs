namespace Checkout.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(string OrderId, UpdateOrderDto UpdateData) : ICommand<UpdateOrderResult>;