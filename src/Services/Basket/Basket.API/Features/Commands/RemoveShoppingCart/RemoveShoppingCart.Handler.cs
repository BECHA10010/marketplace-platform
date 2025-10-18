using Common.Kernel.CQRS.Commands;
namespace Basket.API.Features.Commands.RemoveShoppingCart;

public static partial class RemoveShoppingCart
{
    public class Handler(IShoppingCartRepository repository) : ICommandHandler<Command, Response>
    {
        public async Task<Response> Handle(Command command, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(command.AccountName, cancellationToken);
        
            return new Response(true);
        }
    }
}