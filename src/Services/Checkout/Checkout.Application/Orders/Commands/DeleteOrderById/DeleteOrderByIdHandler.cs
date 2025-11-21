namespace Checkout.Application.Orders.Commands.DeleteOrderById;

public class DeleteOrderByIdHandler(IOrderRepository repository)
    : ICommandHandler<DeleteOrderByIdCommand, DeleteOrderByIdResult>
{
    public async Task<DeleteOrderByIdResult> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
    {
        var orderId = Guid.Parse(command.OrderId);
        var existing = await repository.GetByIdAsync(orderId);

        if (existing is null)
            throw new NotFoundException(nameof(existing), orderId);
        
        var result = await repository.DeleteAsync(existing);
        
        return new DeleteOrderByIdResult(result);
    }
}