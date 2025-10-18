namespace Basket.API.Features.Queries.GetShoppingCart;

public static partial class GetShoppingCart
{
    public record Request(string AccountName);
    public record Query(string AccountName) : IQuery<Response>;

    public record Response(ShoppingCart Cart);
}