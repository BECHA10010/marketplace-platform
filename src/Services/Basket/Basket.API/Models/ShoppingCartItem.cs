namespace Basket.API.Models;

public record ShoppingCartItem(Guid Id, int Quantity, decimal Price, string Title);