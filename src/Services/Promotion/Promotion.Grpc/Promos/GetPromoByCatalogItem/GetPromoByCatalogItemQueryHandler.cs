namespace Promotion.Grpc.Promos.GetPromoByCatalogItem;

public class GetPromoByCatalogItemQueryHandler(IPromoRepository repository)   
    : IQueryHandler<GetPromoByCatalogItemQuery, PromoModel>  
{  
    public async Task<PromoModel> Handle(GetPromoByCatalogItemQuery query, CancellationToken cancellationToken)  
    {  
        var promo = await repository.GetByCatalogItemIdAsync(query.CatalogItemId);  
  
        if (promo is null)
        {
            return new PromoModel
            {
                Value = 0
            };
        }  
  
        var result = promo.Adapt<PromoModel>();  
        return result;  
    }  
}