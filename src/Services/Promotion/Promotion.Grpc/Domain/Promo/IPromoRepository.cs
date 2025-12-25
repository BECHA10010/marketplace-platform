namespace Promotion.Grpc.Domain.Promo;

public interface IPromoRepository
{
    Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId);
    Task<bool> CreateAsync(Promo? promo);
    Task<bool> UpdateAsync(Promo? promo);
    Task<bool> DeleteByCatalogItemIdAsync(string? catalogItemId);
}