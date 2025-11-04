namespace Promotion.Grpc.Persistence.Repositories;

public class PromoRepository(IDbConnection connection) : IPromoRepository  
{  
    public async Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId)  
    {  
        ArgumentNullException.ThrowIfNull(catalogItemId);  
  
        const string selectByCatalogItemId = "SELECT * FROM Promo WHERE CatalogItemId = @catalogItemId LIMIT 1";  
  
        var result = await connection.QueryFirstOrDefaultAsync<Promo>(selectByCatalogItemId, new { catalogItemId });  
  
        return result;  
    }  
}