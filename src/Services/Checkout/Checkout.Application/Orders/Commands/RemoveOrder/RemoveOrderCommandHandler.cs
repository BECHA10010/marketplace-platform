namespace Checkout.Application.Orders.Commands.RemoveOrder;

public class RemoveOrderCommandHandler(IOrderRepository repository)
    : ICommandHandler<RemoveOrderCommand, RemoveOrderResult>
{
    public async Task<RemoveOrderResult> Handle(RemoveOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(command.OrderId, cancellationToken);

        if (order is null)
            return new RemoveOrderResult(false);
        
        order.Cancel();
        
        await repository.DeleteAsync(order, cancellationToken);
        
        return new RemoveOrderResult(true);
    }
}