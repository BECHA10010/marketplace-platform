namespace Checkout.Tests.Integration.Fixtures;

public class PostgresContainerFixture : IAsyncLifetime
{
    public PostgreSqlContainer Container { get; }

    public PostgresContainerFixture()
    {
        Container = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("checkout-integration-test")
            .WithUsername("postgres")
            .WithPassword("123456789")
            .Build();
    }
    
    public async Task InitializeAsync()
    {
        await Container.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await Container.StopAsync();
    }
}