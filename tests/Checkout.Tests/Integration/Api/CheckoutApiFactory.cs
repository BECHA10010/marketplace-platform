using Checkout.Infrastructure.Persistence;

namespace Checkout.Tests.Integration.Api;

public class CheckoutApiFactory : WebApplicationFactory<Program>
{
    private readonly string _connectionString;

    public CheckoutApiFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services
                .FirstOrDefault(s => s.ServiceType == typeof(DbContextOptions<CheckoutDbContext>));

            if (descriptor is not null)
                services.Remove(descriptor);

            services.AddDbContext<CheckoutDbContext>(options =>
            {
                options.UseNpgsql(_connectionString);
            });
        });
    }
}