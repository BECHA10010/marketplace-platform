namespace Checkout.Application.Features.Orders.DeleteOrderById;

public class DeleteOrderByIdHandler(IOrderRepository repository)
    : ICommandHandler<DeleteOrderByIdCommand, DeleteOrderByIdResult>
{
    public async Task<DeleteOrderByIdResult> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(command.OrderId);

        if (order is null)
            return new DeleteOrderByIdResult(false);
        
        await repository.DeleteAsync(order);
        
        return new DeleteOrderByIdResult(true);
    }
}