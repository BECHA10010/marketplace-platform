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
                .FirstOrDefault(s => s.ServiceType == typeof(DbContextOptions<OrderDbContext>));

            if (descriptor is not null)
                services.Remove(descriptor);

            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseNpgsql(_connectionString);
            });
        });
    }
}