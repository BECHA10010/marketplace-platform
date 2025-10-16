namespace Basket.API.Models;

public record ShoppingCart(string AccountName, IReadOnlyList<ShoppingCartItem> Items)
{
    public decimal TotalPrice => Items.Sum(i => i.Quantity * i.Price);
}