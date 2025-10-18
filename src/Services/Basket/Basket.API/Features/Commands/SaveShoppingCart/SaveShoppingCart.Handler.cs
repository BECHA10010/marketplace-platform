using Basket.API.Models;
 using Common.Kernel.CQRS.Commands;
 
 namespace Basket.API.Features.Commands.SaveShoppingCart;
 
 public static partial class SaveShoppingCart
 {
     public class Handler(IShoppingCartRepository repository) : ICommandHandler<Command, Response>
     {
         public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
         {
             var cart = command.Cart;
             
             var existing = await repository.GetAsync(cart.AccountName, cancellationToken);
 
             if (existing is null)
                 await repository.AddAsync(cart, cancellationToken);
             else
                 await repository.UpdateAsync(cart, cancellationToken);
         
             return new Response(cart.AccountName);
         }
     }
 }