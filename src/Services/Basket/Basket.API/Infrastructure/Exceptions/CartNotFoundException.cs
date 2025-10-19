namespace Basket.API.Infrastructure.Exceptions;

public class CartNotFoundException : NotFoundException
{
    public CartNotFoundException(string accountName) : base("ShoppingCart", accountName)
    { }
}