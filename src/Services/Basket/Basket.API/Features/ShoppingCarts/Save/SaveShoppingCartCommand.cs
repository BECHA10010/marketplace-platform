namespace Basket.API.Features.ShoppingCarts.Save;

public record SaveShoppingCartCommand(string AccountName, List<CartItemDto> CartItems) 
    : ICommand<SaveShoppingCartResponse>;