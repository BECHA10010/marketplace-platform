using Promotion.Grpc.Domain.Promo;

namespace Promotion.Grpc.Infrastructure.Persistence.Repositories;

public class PromoRepository(IDbConnection connection) : IPromoRepository  
{  
    public async Task<Promo?> GetByCatalogItemIdAsync(string? catalogItemId)  
    {  
        ArgumentNullException.ThrowIfNull(catalogItemId);  
  
        const string selectByCatalogItemId = "SELECT * FROM Promo WHERE CatalogItemId = @catalogItemId LIMIT 1;";  
  
        var result = await connection.QueryFirstOrDefaultAsync<Promo>(selectByCatalogItemId, new { catalogItemId });  
  
        return result;  
    }

    public async Task<bool> CreateAsync(Promo? promo)
    {
        const string insertPromo = """
                                   INSERT INTO Promo (Id, CatalogItemId, Description, Value)
                                   VALUES (@Id, @CatalogItemId, @Description, @Value);
                                   """;

        var result = await connection.ExecuteAsync(insertPromo, promo);
        return result > 0;
    }

    public async Task<bool> UpdateAsync(Promo? promo)
    {
        const string updatePromo = """
                                   UPDATE Promo
                                   SET Description = @Description,
                                       Value = @Value
                                   WHERE Id = @Id;
                                   """;

        var result = await connection.ExecuteAsync(updatePromo, promo);
        return result > 0;
    }

    public async Task<bool> DeleteByCatalogItemIdAsync(string? catalogItemId)
    {
        const string deletePromo = """
                                   DELETE FROM Promo WHERE CatalogItemId = @catalogItemId;
                                   """;
        
        var result = await connection.ExecuteAsync(deletePromo, new { catalogItemId });
        return result > 0;
    }
}