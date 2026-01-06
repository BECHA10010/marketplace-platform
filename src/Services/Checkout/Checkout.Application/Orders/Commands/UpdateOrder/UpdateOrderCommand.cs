namespace Checkout.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(Guid OrderId, UpdateOrderDto UpdateData) : ICommand<UpdateOrderResult>;