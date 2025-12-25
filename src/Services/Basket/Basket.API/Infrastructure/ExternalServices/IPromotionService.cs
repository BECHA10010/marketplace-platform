namespace Basket.API.Infrastructure.ExternalServices;

public interface IPromotionService
{
    Task<decimal> GetDiscountAsync(Guid catalogItemId, CancellationToken ct);
}