namespace Checkout.Tests.Integration.Api.Orders;

[Collection("IntegrationTests")]
public class CancelOrderTests : IClassFixture<CheckoutApiFactory>, IAsyncLifetime
{
    private readonly HttpClient _client;
    private readonly OrderDbContext _context;
    
    public CancelOrderTests(CheckoutApiFactory factory)
    {
        _client = factory.CreateClient();
        _context = factory.Services.GetRequiredService<OrderDbContext>();
    }
    
    [Fact]
    public async Task CancelOrderById_WhenIdIsValidAndExisting_ShouldReturn204NoContent()
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        
        // Act
        var response = await _client.DeleteAsync($"/orders/{order.Id}");
        
        // Assert - API
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        
        // Assert - Database
        var existing = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == order.Id);
        
        Assert.Null(existing);
    }
    
    [Fact]
    public async Task CancelOrderById_WhenIdIsNotExisting_ShouldReturn404NotFound()
    {
        // Arrange
        var notExistingId = Guid.NewGuid().ToString();
        
        // Act
        var deleteOrderResponse = await _client.DeleteAsync($"/orders/{notExistingId}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, deleteOrderResponse.StatusCode);
    }
    
    [Fact]
    public async Task CancelOrderById_WhenIdIsInvalidGuid_ShouldReturn400BadRequest()
    {
        // Arrange
        var invalidGuid = Guid.NewGuid().ToString()[..^4];
        
        // Act
        var response = await _client.DeleteAsync($"/orders/{invalidGuid}");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    public async Task InitializeAsync() => await DatabaseCleaner.ClearAsync(_context);
    
    public Task DisposeAsync() => Task.CompletedTask;
}