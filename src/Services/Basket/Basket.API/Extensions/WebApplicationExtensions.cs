namespace Basket.API.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        app.MapCarter();
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }
}