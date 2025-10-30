namespace Basket.API.Features.ShoppingCarts.Commands.SaveShoppingCart;

public static partial class SaveShoppingCart
{
    public record SaveShoppingCartRequest(ShoppingCart Cart);
    
    public record SaveShoppingCartCommand(ShoppingCart Cart) : ICommand<SaveShoppingCartResponse>;

    public record SaveShoppingCartResponse(string AccountName);
}