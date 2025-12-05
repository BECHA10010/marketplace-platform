namespace Checkout.Tests.Integration.Api.Orders;

[Collection("IntegrationTests")]
public class UpdateOrderTests : IClassFixture<CheckoutApiFactory>, IAsyncLifetime
{
    private readonly HttpClient _client;
    private readonly OrderDbContext _context;
    
    public static IEnumerable<object[]> ValidUpdateRequests => 
        new List<object[]>
        {
            new object[] { UpdateOrderRequests.ValidRequest_UpdateContactData() },
            new object[] { UpdateOrderRequests.ValidRequest_UpdateAddressData() },
            new object[] { UpdateOrderRequests.ValidRequest_UpdatePaymentMethodToBankTransfer() },
            new object[] { UpdateOrderRequests.ValidRequest_UpdatePaymentMethodToCreditCard() },
            new object[] { UpdateOrderRequests.ValidRequest_UpdateCardDetails() },
            new object[] { UpdateOrderRequests.ValidRequest_UpdateEverything() }
        };
    
    public UpdateOrderTests(CheckoutApiFactory factory)
    {
        _client = factory.CreateClient();
        _context = factory.Services.GetRequiredService<OrderDbContext>();
    }
    
    [Theory]
    [MemberData(nameof(ValidUpdateRequests))]
    public async Task UpdateOrder_WhenRequestIsValid_ShouldReturn200Ok(UpdateOrderRequest request)
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        
        var content = JsonContent.Create(request);
        
        // Act
        var response = await _client.PatchAsync($"/orders/{order.Id}", content);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdateOrder_WhenIdIsInvalidGuid_ShouldReturn400BadRequest()
    {
        // Arrange
        var invalidGuid = Guid.NewGuid().ToString()[..^10];
        var request = UpdateOrderRequests.ValidRequest_UpdateAddressData();
        var content = JsonContent.Create(request);
        
        // Act
        var response = await _client.PatchAsync($"/orders/{invalidGuid}", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdateOrder_WhenRequestIsInvalid_ShouldReturn400BadRequest()
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        var request = UpdateOrderRequests.InvalidRequest_UpdateToInvalidPaymentMethod();
        var content = JsonContent.Create(request);
        
        // Act
        var response = await _client.PatchAsync($"/orders/{order.Id}", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdateOrder_WhenOrderIsNotExisting_ShouldReturn404NotFound()
    {
        // Arrange
        var notExistingId = Guid.NewGuid().ToString();
        var request = UpdateOrderRequests.ValidRequest_UpdateAddressData();
        var content = JsonContent.Create(request);
        
        // Act
        var response = await _client.PatchAsync($"/orders/{notExistingId}", content);
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
        
    public async Task InitializeAsync() => await DatabaseCleaner.ClearAsync(_context);
    
    public Task DisposeAsync() => Task.CompletedTask;
}