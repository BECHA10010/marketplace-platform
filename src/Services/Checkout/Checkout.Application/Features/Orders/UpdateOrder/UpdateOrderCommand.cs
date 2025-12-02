namespace Checkout.Application.Features.Orders.UpdateOrder;

public record UpdateOrderCommand(Guid OrderId, UpdateOrderDto UpdateData) : ICommand<UpdateOrderResult>;