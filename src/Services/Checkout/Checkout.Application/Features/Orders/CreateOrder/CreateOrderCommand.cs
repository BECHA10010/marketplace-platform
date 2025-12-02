namespace Checkout.Application.Features.Orders.CreateOrder;

public record CreateOrderCommand(CreateOrderDto OrderData) : ICommand<CreateOrderResult>;