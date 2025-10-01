using Catalog.Application.Behaviors;
using Catalog.Application.Domains.CatalogItems.Queries.GetCatalogItemById;
using FluentValidation;

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssemblyContaining<GetCatalogItemByIdQuery>();
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}