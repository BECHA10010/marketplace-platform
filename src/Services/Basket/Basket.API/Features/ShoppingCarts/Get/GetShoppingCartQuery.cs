namespace Basket.API.Features.ShoppingCarts.Get;

public record GetShoppingCartQuery(string AccountName) : IQuery<ShoppingCartResponse>;