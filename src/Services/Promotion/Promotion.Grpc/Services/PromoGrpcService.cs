using Grpc.Core;
using Promotion.Grpc.Protos;

namespace Promotion.Grpc.Services;

public class PromoGrpcService : PromoService.PromoServiceBase
{
    public override Task<PromoModel> GetPromo(GetPromoRequest request, ServerCallContext context)
    {
        return base.GetPromo(request, context);
    }
}