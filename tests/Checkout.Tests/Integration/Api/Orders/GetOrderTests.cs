using Checkout.API.Orders.GetOrdersByAccount;

namespace Checkout.Tests.Integration.Api.Orders;

public class GetOrderTests : IntegrationTestBase
{
    public GetOrderTests(PostgresContainerFixture fixture)
        : base(fixture) { }
    
    [Fact]
    public async Task GetOrdersByAccount_WhenAccountIsValidAndExisting_ShouldReturn200Ok()
    {
        // Arrange
        var order = TestOrderFactory.CreateValidOrder();
        await Context.Orders.AddAsync(order);
        await Context.SaveChangesAsync();
        
        // Act
        var response = await Client.GetAsync($"/orders/{order.AccountName}");
        
        // Assert
        var accountOrders = await response.Content.ReadFromJsonAsync<GetOrdersByAccountResponse>();
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(accountOrders!.Orders);
        Assert.Single(accountOrders.Orders);
    }
    
    [Theory]
    [InlineData("ab")]
    [InlineData("ab132ab132ab132ab1321")]
    [InlineData("ab132ab13$")]
    public async Task GetOrdersByAccount_WhenAccountIsInvalid_ShouldReturn400BadRequest(string accountName)
    {
        // Act
        var response = await Client.GetAsync($"/orders/{accountName}");
        
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task GetOrdersByAccount_WhenAccountIsNotExisting_ShouldReturn200Ok()
    {
        // Arrange
        var accountName = Guid.NewGuid().ToString()[..^21];
        
        // Act
        var response = await Client.GetAsync($"/orders/{accountName}");
        
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}