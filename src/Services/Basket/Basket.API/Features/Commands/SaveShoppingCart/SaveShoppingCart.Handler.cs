namespace Basket.API.Features.Commands.SaveShoppingCart;
 
public static partial class SaveShoppingCart
{
    public class Handler(IShoppingCartRepository repository) : ICommandHandler<SaveShoppingCartCommand, SaveShoppingCartResponse>
    {
         public async Task<SaveShoppingCartResponse> Handle(SaveShoppingCartCommand command, CancellationToken cancellationToken)
         {
             var cart = command.Cart;
             await repository.AddAsync(cart, cancellationToken);
             
             return new SaveShoppingCartResponse(cart.AccountName);
         }
    }
}