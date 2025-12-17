namespace Basket.API.Infrastructure.Caching.Mappings;

public static class DomainToCachedDtoMapper
{
    public static CachedShoppingCartDto ToCachedDto(this ShoppingCart cart)
    {
        var items = cart.Items.Select(i => new CachedCartItemDto(
            i.CatalogItemId, 
            i.Title, 
            i.Quantity, 
            i.UnitPrice,
            i.Discount)).ToList();
        
        return new CachedShoppingCartDto(cart.AccountName, items);
    }
}