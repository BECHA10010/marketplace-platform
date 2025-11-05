namespace Promotion.Grpc.GrpcServices;  
  
public class PromoGrpcService(IMediator mediator) : PromoService.PromoServiceBase  
{  
    public override async Task<PromoModel> GetPromo(GetPromoRequest request, ServerCallContext context)  
    {  
        var query = new GetPromoByCatalogItemIdQuery(request.CatalogItemId);  
        var result = await mediator.Send(query);  
        return result;  
    }

    public override async Task<CreatePromoResponse> CreatePromo(CreatePromoRequest request, ServerCallContext context)
    {
        var command = new CreatePromoCommand(request);
        var result = await mediator.Send(command);
        return result;
    }

    public override async Task<UpdatePromoResponse> UpdatePromo(UpdatePromoRequest request, ServerCallContext context)
    {
        var command = new UpdatePromoCommand(request);
        var result = await mediator.Send(command);
        return result;
    }

    public override async Task<DeletePromoResponse> DeletePromo(DeletePromoRequest request, ServerCallContext context)
    {
        var command = new DeletePromoCommand(request.CatalogItemId);
        var result = await mediator.Send(command);
        return result;
    }
}