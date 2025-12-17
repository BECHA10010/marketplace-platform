namespace Basket.API.Domain.Abstractions;

public interface IPromotionService
{
    Task<decimal> GetDiscountAsync(Guid catalogItemId, CancellationToken ct);
}