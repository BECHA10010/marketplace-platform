namespace Checkout.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IOrderRepository repository) : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = command.OrderData.Adapt<Order>();
        order.CurrentOrderStatus = OrderStatus.Draft;
        order.CurrentPaymentStatus = PaymentStatus.Pending;
        
        await repository.AddAsync(order);

        return new CreateOrderResult(order.Id, "Order success created");
    }
}