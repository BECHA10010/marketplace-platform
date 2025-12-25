namespace Basket.API.ShoppingCarts.SaveCart;

public static class SaveCartMapping
{
    public static SaveCartCommand ToCommand(this SaveCartRequest request)
    {
        var items = request.CartItems.Select(i => new SaveCartItemDto(
            i.CatalogItemId,
            i.Title,
            i.Quantity,
            i.UnitPrice)).ToList();

        return new SaveCartCommand(request.AccountName, items);
    }
}