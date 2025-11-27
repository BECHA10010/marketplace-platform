namespace Checkout.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderHandler(IOrderRepository repository)
    : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(command.OrderId);
        var existing = await repository.GetByIdAsync(id);

        if (existing is null)
            throw new NotFoundException(nameof(Order), command.OrderId);
        
        command.UpdateData.Adapt(existing);

        var result = await repository.UpdateAsync(existing);

        return new UpdateOrderResult(result);
    }
}