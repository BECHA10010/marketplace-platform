namespace Basket.API.ShoppingCarts.CheckoutCart;

public class CheckoutCartCommandHandler(IPublishEndpoint publishEndpoint, ISender sender) 
    : ICommandHandler<CheckoutCartCommand, CheckoutCartResult>
{
    public async Task<CheckoutCartResult> Handle(CheckoutCartCommand command, CancellationToken cancellationToken)
    {
        var getCartQuery = new GetCartByAccountQuery(command.AccountName);
        var getCartResult = await sender.Send(getCartQuery, cancellationToken);

        if (getCartResult.Cart is null)
            throw new NotFoundException(nameof(ShoppingCart), command.AccountName);

        var submittedEvent = command.ToEvent(getCartResult.Cart);
        await publishEndpoint.Publish(submittedEvent, cancellationToken);

        /*var clearCartCommand = new ClearCartCommand(command.AccountName);
        var clearCartResult = await sender.Send(clearCartCommand, cancellationToken);*/

        return new CheckoutCartResult(command.CorrelationId, true); //clearCartResult.IsSuccess);
    }
}

public record CheckoutCartResult(Guid CorrelationId, bool Removed);