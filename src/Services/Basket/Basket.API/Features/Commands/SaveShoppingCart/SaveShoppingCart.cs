namespace Basket.API.Features.Commands.SaveShoppingCart;

public static partial class SaveShoppingCart
{
    public record Request(ShoppingCart Cart);
    
    public record Command(ShoppingCart Cart) : ICommand<Response>;

    public record Response(string AccountName);
}