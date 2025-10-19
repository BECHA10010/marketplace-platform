namespace Basket.API.Features.Queries.GetShoppingCart;

public static partial class GetShoppingCart
{
    public record GetShoppingCartRequest(string AccountName);
    public record GetShoppingCartQuery(string AccountName) : IQuery<GetShoppingCartResponse>;

    public record GetShoppingCartResponse(ShoppingCart Cart);
}