namespace Basket.API.Features.ShoppingCarts.Save;

public record SaveShoppingCartRequest(string AccountName, List<CartItemRequest> CartItems);