namespace Basket.API.Features.ShoppingCarts.Commands.RemoveShoppingCart;

public static partial class RemoveShoppingCart
{
    public class Handler(IShoppingCartRepository repository) : ICommandHandler<RemoveShoppingCartCommand, RemoveShoppingCartResponse>
    {
        public async Task<RemoveShoppingCartResponse> Handle(RemoveShoppingCartCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(command.AccountName, cancellationToken);
        
            return new RemoveShoppingCartResponse(true);
        }
    }
}