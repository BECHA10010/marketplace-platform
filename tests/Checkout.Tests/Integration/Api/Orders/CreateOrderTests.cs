namespace Checkout.Tests.Integration.Api.Orders;

[Collection("IntegrationTests")]
public class CreateOrderTests : IClassFixture<CheckoutApiFactory>, IAsyncLifetime
{
    private readonly HttpClient _client;
    private readonly OrderDbContext _context;
    
    public CreateOrderTests(CheckoutApiFactory factory)
    {
        _client = factory.CreateClient();
        _context = factory.Services.GetRequiredService<OrderDbContext>();
    }

    [Fact]
    public async Task CreateOrder_WhenValidCreditCard_ShouldReturn201Created()
    {
        // Arrange
        var request = CreateOrderRequests.ValidRequest_CreateWithCreditCard();
        
        // Act
        var response = await _client.PostAsJsonAsync("/orders", request);
        
        // Assert - API
        var createdOrder = await response.Content.ReadFromJsonAsync<CreateOrderResponse>();
        
        Assert.NotNull(createdOrder);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotEqual(Guid.Empty, createdOrder.OrderId);
        
        // Assert - Database
        var order = _context.Orders.FirstOrDefault(o => o.Id == createdOrder.OrderId);
        
        Assert.NotNull(order);
        Assert.Equal(request.AccountName, order.AccountName);
        Assert.Equal(OrderStatus.Draft, order.Status);
        Assert.Equal(PaymentMethod.CreditCard, order.PaymentMethod);
    }
    
    [Fact]
    public async Task CreateOrder_WhenValidBankTransfer_ShouldReturn201Created()
    {
        // Arrange
        var request = CreateOrderRequests.ValidRequest_CreateWithBankTransfer();
        
        // Act
        var response = await _client.PostAsJsonAsync("/orders", request);
        
        // Assert - API
        var createdOrder = await response.Content.ReadFromJsonAsync<CreateOrderResponse>();
        
        Assert.NotNull(createdOrder);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotEqual(Guid.Empty, createdOrder.OrderId);
        
        // Assert - Database
        var order = _context.Orders.FirstOrDefault(o => o.Id == createdOrder.OrderId);
        
        Assert.NotNull(order);
        Assert.Equal(request.AccountName, order.AccountName);
        Assert.Equal(OrderStatus.Draft, order.Status);
        Assert.Single(order.Items);
        Assert.Equal(PaymentMethod.BankTransfer, order.PaymentMethod);
    }
    
    [Fact]
    public async Task CreateOrder_WhenCardPaymentWithoutDetails_ShouldReturn400BadRequest()
    {
        var request = CreateOrderRequests.InvalidRequest_CreateWithCardPaymentWithoutDetails();
        
        var response = await _client.PostAsJsonAsync("/orders", request);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task CreateOrder_WhenBankTransferWithCardDetails_ShouldReturn400BadRequest()
    {
        var request = CreateOrderRequests.InvalidRequest_CreateWithBankTransferAndCardDetails();
        
        var response = await _client.PostAsJsonAsync("/orders", request);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task CreateOrder_WhenItemsIsEmpty_ShouldReturn400BadRequest()
    {
        var request = CreateOrderRequests.InvalidRequest_CreateWithEmptyItems();
        
        var response = await _client.PostAsJsonAsync("/orders", request);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    public async Task InitializeAsync() => await DatabaseCleaner.ClearAsync(_context);
    
    public Task DisposeAsync() => Task.CompletedTask;
}