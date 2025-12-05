namespace Checkout.Tests.Integration.Api.Orders;

[Collection("IntegrationTests")]
public class GetOrderTests : IClassFixture<CheckoutApiFactory>, IAsyncLifetime
{
    private readonly HttpClient _client;
    private readonly OrderDbContext _context;
    
    public GetOrderTests(CheckoutApiFactory factory)
    {
        _client = factory.CreateClient();
        _context = factory.Services.GetRequiredService<OrderDbContext>();
    }
    
    [Fact]
    public async Task GetOrdersByAccount_WhenAccountIsValidAndExisting_ShouldReturn200Ok()
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        
        // Act
        var response = await _client.GetAsync($"/orders?AccountName={order.AccountName}");
        
        // Assert
        var accountOrders = await response.Content.ReadFromJsonAsync<GetOrdersByAccountNameResponse>();
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(accountOrders!.Orders);
        Assert.Single(accountOrders.Orders);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("ab")]
    [InlineData("ab132ab132ab132ab1321")]
    [InlineData("ab132ab13$")]
    public async Task GetOrdersByAccount_WhenAccountIsInvalid_ShouldReturn400BadRequest(string accountName)
    {
        // Act
        var response = await _client.GetAsync($"/orders?AccountName={accountName}");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task GetOrdersByAccount_WhenAccountIsNotExisting_ShouldReturn200Ok()
    {
        // Arrange
        var accountName = Guid.NewGuid().ToString()[..^21];
        
        // Act
        var response = await _client.GetAsync($"/orders?AccountName={accountName}");
        
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
        
    public async Task InitializeAsync() => await DatabaseCleaner.ClearAsync(_context);
    
    public Task DisposeAsync() => Task.CompletedTask;
}