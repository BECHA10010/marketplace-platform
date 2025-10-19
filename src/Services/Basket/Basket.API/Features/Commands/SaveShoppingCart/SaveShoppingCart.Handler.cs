namespace Basket.API.Features.Commands.SaveShoppingCart;
 
public static partial class SaveShoppingCart
{
 public class Handler(IShoppingCartRepository repository) : ICommandHandler<Command, Response>
 {
     public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
     {
         var cart = command.Cart;
         await repository.AddAsync(cart, cancellationToken);
         
         return new Response(cart.AccountName);
     }
 }
}