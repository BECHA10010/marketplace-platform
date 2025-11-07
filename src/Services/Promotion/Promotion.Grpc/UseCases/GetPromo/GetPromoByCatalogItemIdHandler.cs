namespace Promotion.Grpc.UseCases.GetPromo;

public class GetPromoByCatalogItemIdHandler(IPromoRepository repository)   
    : IQueryHandler<GetPromoByCatalogItemIdQuery, PromoModel>  
{  
    public async Task<PromoModel> Handle(GetPromoByCatalogItemIdQuery query, CancellationToken cancellationToken)  
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