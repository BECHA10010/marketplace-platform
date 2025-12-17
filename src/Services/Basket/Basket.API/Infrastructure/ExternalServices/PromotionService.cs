namespace Basket.API.Infrastructure.ExternalServices;

public class PromotionService(PromoService.PromoServiceClient promoClient) 
    : IPromotionService
{
    public async Task<decimal> GetDiscountAsync(Guid catalogItemId, CancellationToken ct)
    {
        var request = new GetPromoRequest
        {
            CatalogItemId = catalogItemId.ToString()
        };
        
        var response = await promoClient.GetPromoAsync(request, cancellationToken: ct);

        return (decimal)response.Value;
    }
}