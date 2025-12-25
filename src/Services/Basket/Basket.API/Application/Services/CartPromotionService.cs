using Basket.API.Domain.ShoppingCart;

namespace Basket.API.Application.Services;

public class CartPromotionService(IPromotionService promoService) : ICartPromotionService
{
    public async Task ApplyPromotionsAsync(ShoppingCart cart, CancellationToken ct)
    {
        var tasks = cart.Items.Select(async item =>
        {
            var discount = await promoService.GetDiscountAsync(item.CatalogItemId, ct);
            return (item.CatalogItemId, discount);
        });

        var discounts = await Task.WhenAll(tasks);

        foreach (var (itemId, discount) in discounts)
            cart.ApplyDiscountForItem(itemId, discount);
    }
}