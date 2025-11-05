namespace Promotion.Grpc.Domain.Interfaces;

public interface IPromoRepository
{
    Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId);
    Task<bool> CreateAsync(Promo? promo);
    Task<bool> UpdateAsync(Promo? promo);
}