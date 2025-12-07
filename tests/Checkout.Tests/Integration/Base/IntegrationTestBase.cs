namespace Checkout.Tests.Integration.Base;

[Collection("IntegrationTests")]
public abstract class IntegrationTestBase : IAsyncLifetime
{
    private readonly IServiceScope _scope;
 
    protected readonly HttpClient Client;
    protected readonly OrderDbContext Context;
    
    protected IntegrationTestBase(PostgresContainerFixture fixture)
    {
        var factory = new CheckoutApiFactory(fixture.Container.GetConnectionString());

        Client = factory.CreateClient();
        _scope = factory.Services.CreateScope();
        Context = _scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    }

    public async Task InitializeAsync()
    {
        await Context.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await Context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE \"Orders\" CASCADE;");
        _scope.Dispose();
    }
}