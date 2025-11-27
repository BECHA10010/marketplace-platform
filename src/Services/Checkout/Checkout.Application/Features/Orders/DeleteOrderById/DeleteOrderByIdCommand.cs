namespace Checkout.Application.Features.Orders.DeleteOrderById;

public record DeleteOrderByIdCommand(Guid OrderId) : ICommand<DeleteOrderByIdResult>;