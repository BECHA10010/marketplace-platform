namespace Basket.API.Features.Commands.RemoveShoppingCart;

public static partial class RemoveShoppingCart
{
    public record RemoveShoppingCartRequest(string AccountName);
    
    public record RemoveShoppingCartCommand(string AccountName) : ICommand<RemoveShoppingCartResponse>;

    public record RemoveShoppingCartResponse(bool IsSuccess);
}