namespace Promotion.Grpc.UseCases.GetPromo;

public class GetPromoByCatalogItemIdHandler(IPromoRepository repository)   
    : IQueryHandler<GetPromoByCatalogItemIdQuery, PromoModel>  
{  
    public async Task<PromoModel> Handle(GetPromoByCatalogItemIdQuery query, CancellationToken cancellationToken)  
    {  
        var promo = await repository.GetByCatalogItemIdAsync(query.CatalogItemId);  
  
        if (promo is null)  
        {  
            throw new RpcException(new Status(StatusCode.NotFound, $"Promotion for key {query.CatalogItemId} was not found"));  
        }  
  
        var result = promo.Adapt<PromoModel>();  
        return result;  
    }  
}