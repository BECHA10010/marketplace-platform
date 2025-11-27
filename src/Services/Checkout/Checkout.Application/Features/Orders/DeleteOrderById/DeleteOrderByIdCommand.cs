namespace Checkout.Application.Orders.Commands.DeleteOrderById;

public record DeleteOrderByIdCommand(string OrderId) : ICommand<DeleteOrderByIdResult>;