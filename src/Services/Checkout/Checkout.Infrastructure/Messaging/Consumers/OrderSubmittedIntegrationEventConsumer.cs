namespace Checkout.Infrastructure.Messaging.Consumers;

public class OrderSubmittedIntegrationEventConsumer(ISender sender) : IConsumer<OrderSubmittedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<OrderSubmittedIntegrationEvent> context)
    {
        var command = context.Message.ToCommand();

        await sender.Send(command);
    }
}