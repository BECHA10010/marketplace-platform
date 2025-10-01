namespace Catalog.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(config =>
        {
            var basePath = AppContext.BaseDirectory;
            config.IncludeXmlComments(Path.Combine(basePath, "Catalog.Domain.xml"));
        });
        
        var applicationAssembly = typeof(ApplicationErrors).Assembly;
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(applicationAssembly);
        });

        services.AddProblemDetails(options =>
        {
            options.MapFluentValidationException();
            options.ValidationProblemStatusCode = StatusCodes.Status422UnprocessableEntity;
            options.IncludeExceptionDetails = (_, _) => false;
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        });
        
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
     
        app.UseProblemDetails();
        
        app.MapControllers();
        
        return app;
    }
}