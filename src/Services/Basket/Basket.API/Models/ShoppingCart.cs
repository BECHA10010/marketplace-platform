namespace Basket.API.Models;

public class ShoppingCart
{
    public string AccountName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = [];
    public decimal TotalPrice => Items.Sum(i => i.Quantity * i.Price);

    public ShoppingCart() { }

    public ShoppingCart(string accountName)
    {
        AccountName = accountName;
    }
}