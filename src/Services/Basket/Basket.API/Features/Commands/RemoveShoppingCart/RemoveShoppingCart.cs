using Common.Kernel.CQRS.Commands;

namespace Basket.API.Features.Commands.RemoveShoppingCart;

public static partial class RemoveShoppingCart
{
    public record Request(string AccountName);
    
    public record Command(string AccountName) : ICommand<Response>;

    public record Response(bool IsSuccess);
}