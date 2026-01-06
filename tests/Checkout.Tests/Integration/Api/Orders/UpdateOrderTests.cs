using Checkout.API.Orders.Requests;

namespace Checkout.Tests.Integration.Api.Orders;

public class UpdateOrderTests : IntegrationTestBase
{
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
    
    public UpdateOrderTests(PostgresContainerFixture fixture)
        : base(fixture) { }
    
    [Theory]
    [MemberData(nameof(ValidUpdateRequests))]
    public async Task UpdateOrder_WhenRequestIsValid_ShouldReturn204NoContent(UpdateOrderRequest request)
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await Context.Orders.AddAsync(order);
        await Context.SaveChangesAsync();
        
        var content = JsonContent.Create(request);
        
        // Act
        var response = await Client.PatchAsync($"/orders/{order.Id}", content);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdateOrder_WhenIdIsInvalidGuid_ShouldReturn404NotFound()
    {
        // Arrange
        var invalidGuid = Guid.NewGuid().ToString()[..^10];
        var request = UpdateOrderRequests.ValidRequest_UpdateAddressData();
        var content = JsonContent.Create(request);
        
        // Act
        var response = await Client.PatchAsync($"/orders/{invalidGuid}", content);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdateOrder_WhenRequestIsInvalid_ShouldReturn400BadRequest()
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await Context.Orders.AddAsync(order);
        await Context.SaveChangesAsync();

        var request = UpdateOrderRequests.InvalidRequest_UpdateToInvalidPaymentMethod();
        var content = JsonContent.Create(request);
        
        // Act
        var response = await Client.PatchAsync($"/orders/{order.Id}", content);

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
        var response = await Client.PatchAsync($"/orders/{notExistingId}", content);
        
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}