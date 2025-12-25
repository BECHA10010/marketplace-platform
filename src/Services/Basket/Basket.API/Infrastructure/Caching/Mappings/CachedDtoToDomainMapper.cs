using Basket.API.Domain.ShoppingCart;

namespace Basket.API.Infrastructure.Caching.Mappings;

public static class CachedDtoToDomainMapper
{
    public static ShoppingCart ToDomain(this CachedShoppingCartDto dto)
    {
        var cart = ShoppingCart.Create(dto.AccountName);

        foreach (var item in dto.Items)
        {
            cart.AddItem(item.CatalogItemId, item.Title, item.Quantity, item.UnitPrice);
            cart.ApplyDiscountForItem(item.CatalogItemId, item.Discount);
        }

        return cart;
    }
}