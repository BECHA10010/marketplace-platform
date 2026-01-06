namespace Basket.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(Program).Assembly;
        
        var pgConnection = configuration.GetConnectionString("PgConnection")!;
        var redisConnection = configuration.GetConnectionString("RedisConnection")!;
        var promotionService = configuration.GetSection("GrpcServices:PromotionService").Value!;
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCarter();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        services.AddValidatorsFromAssembly(assembly);
        services.AddFluentValidationAutoValidation();
        
        services.AddGrpcClient<PromoService.PromoServiceClient>(options =>
        {
            options.Address = new Uri(promotionService);
        });
        
        services.AddScoped<ICartPromotionService, CartPromotionService>();
        services.AddScoped<IPromotionService, PromotionService>();
        
        services.AddDbContext<BasketDbContext>(options =>
        {
            options.UseNpgsql(pgConnection);
        });
        
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnection;
            options.InstanceName = "basket: ";
        });
        
        services.AddScoped<IShoppingCartReadRepository, ShoppingCartReadRepository>();
        services.AddScoped<IShoppingCartWriteRepository, ShoppingCartWriteRepository>();
        
        services.Decorate<IShoppingCartReadRepository, CachedShoppingCartReadRepository>();

        services.AddBroker(configuration);
        
        return services;
    }
}