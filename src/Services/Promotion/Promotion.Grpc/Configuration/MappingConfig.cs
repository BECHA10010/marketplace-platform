namespace Promotion.Grpc.Configuration;

public static class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<CreatePromoRequest, Promo>
            .NewConfig()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Value, src => (decimal)src.Value);

        TypeAdapterConfig<UpdatePromoRequest, Promo>
            .NewConfig()
            .Map(dest => dest.Id, src => Guid.Parse(src.Id))
            .Map(dest => dest.Value, src => (decimal)src.Value);
    }
}