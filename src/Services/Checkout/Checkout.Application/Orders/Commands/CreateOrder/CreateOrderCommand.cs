namespace Checkout.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(CreateOrderDto OrderData) : ICommand<CreateOrderResult>;