namespace Basket.API.Application.Services;

public interface ICartPromotionService
{
    Task ApplyPromotionsAsync(ShoppingCart cart, CancellationToken ct);
}