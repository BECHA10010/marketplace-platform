namespace Basket.API.Infrastructure.Exceptions;

public class CartAlreadyExistException : AlreadyExistException
{
    public CartAlreadyExistException(string accountName) : base("ShoppingCart", accountName)
    { }
}