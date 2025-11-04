namespace Promotion.Grpc.Persistence.Interfaces;

public interface IPromoRepository
{
    Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId);
    Task<bool> CreateAsync(Promo? promo);
    Task<bool> UpdateAsync(Promo? promo);
}