namespace Basket.API.Domain.ShoppingCart;

public interface ICartPromotionService
{
    Task ApplyPromotionsAsync(ShoppingCart cart, CancellationToken ct);
}