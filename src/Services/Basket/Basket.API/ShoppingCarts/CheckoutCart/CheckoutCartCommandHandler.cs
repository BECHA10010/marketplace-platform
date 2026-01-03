using Basket.API.ShoppingCarts.ClearCart;
using Basket.API.ShoppingCarts.GetCartByAccount;

namespace Basket.API.ShoppingCarts.CheckoutCart;

public class CheckoutCartCommandHandler(IPublishEndpoint publishEndpoint, ISender sender) 
    : ICommandHandler<CheckoutCartCommand, CheckoutCartResult>
{
    public async Task<CheckoutCartResult> Handle(CheckoutCartCommand command, CancellationToken cancellationToken)
    {
        var accountName = command.AccountName;
        
        var getCartQuery = new GetCartByAccountQuery(accountName);
        var getCartResult = await sender.Send(getCartQuery, cancellationToken);

        if (getCartResult.Cart is null)
            throw new NotFoundException(nameof(ShoppingCart), accountName);

        var orderId = Guid.NewGuid();
        var submittedEvent = command.ToEvent(getCartResult.Cart);
        submittedEvent.OrderId = orderId;
        
        await publishEndpoint.Publish(submittedEvent, cancellationToken);

        var clearCartCommand = new ClearCartCommand(command.AccountName);
        var clearCartResult = await sender.Send(clearCartCommand, cancellationToken);

        return new CheckoutCartResult(
            orderId, 
            command.CorrelationId, 
            clearCartResult.IsSuccess
        );
    }
}

public record CheckoutCartCommand(
    string AccountName,
    string FirstName,
    string LastName,
    string Email,
    string Street,
    string City,
    int PaymentMethod,
    string? CardNumber,
    string? Expiration,
    string? CvvCode,
    string CorrelationId
) : ICommand<CheckoutCartResult>;

public record CheckoutCartResult(Guid OrderId, string CorrelationId, bool Removed);