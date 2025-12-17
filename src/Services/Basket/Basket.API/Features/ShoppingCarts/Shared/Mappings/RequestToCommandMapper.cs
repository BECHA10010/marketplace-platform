namespace Basket.API.Features.ShoppingCarts.Shared.Mappings;

public static class RequestToCommandMapper
{
    public static SaveShoppingCartCommand ToCommand(this SaveShoppingCartRequest request)
    {
        var items = request.CartItems.Select(i => new CartItemDto(
            i.CatalogItemId,
            i.Title,
            i.Quantity,
            i.UnitPrice)).ToList();

        return new SaveShoppingCartCommand(request.AccountName, items);
    }
}