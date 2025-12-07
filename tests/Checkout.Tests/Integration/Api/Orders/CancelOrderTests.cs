namespace Checkout.Tests.Integration.Api.Orders;

public class CancelOrderTests : IntegrationTestBase
{
    public CancelOrderTests(PostgresContainerFixture fixture) : base(fixture) { }
    
    [Fact]
    public async Task CancelOrderById_WhenIdIsValidAndExisting_ShouldReturn204NoContent()
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await Context.Orders.AddAsync(order);
        await Context.SaveChangesAsync();
        
        // Act
        var response = await Client.DeleteAsync($"/orders/{order.Id}");
        
        // Assert - API
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        
        // Assert - Database
        var existing = await Context.Orders
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
        var deleteOrderResponse = await Client.DeleteAsync($"/orders/{notExistingId}");
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, deleteOrderResponse.StatusCode);
    }
    
    [Fact]
    public async Task CancelOrderById_WhenIdIsInvalidGuid_ShouldReturn400BadRequest()
    {
        // Arrange
        var invalidGuid = Guid.NewGuid().ToString()[..^4];
        
        // Act
        var response = await Client.DeleteAsync($"/orders/{invalidGuid}");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}