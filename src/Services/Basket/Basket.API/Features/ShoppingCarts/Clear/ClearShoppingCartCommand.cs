namespace Basket.API.Features.ShoppingCarts.Clear;

public record ClearShoppingCartCommand(string AccountName) : ICommand<ClearShoppingCartResponse>;