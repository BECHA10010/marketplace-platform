namespace Checkout.Tests.Unit.Domain.Orders;

public class OrderDeliveryAddressTests
{
    [Fact]
    public void ChangeDeliveryAddress_InDraftStatus_ShouldUpdateAddress()
    {
        var order = TestOrderFactory.CreateValidOrder();
        
        order.ChangeDeliveryAddress("Новая 15", "Москва");
        
        Assert.Equal("Новая 15", order.DeliveryAddress!.Street);
        Assert.Equal("Москва", order.DeliveryAddress!.City);
    }
    
    [Theory]
    [InlineData(OrderStatus.Submitted)]
    [InlineData(OrderStatus.Paid)]
    [InlineData(OrderStatus.Shipped)]
    [InlineData(OrderStatus.Cancelled)]
    public void ChangeDeliveryAddress_WhenNotDraftStatus_ShouldThrow(OrderStatus status)
    {
        var order = TestOrderFactory.CreateValidOrder();
        order.SetOrderStatus(status);

        Assert.Throws<DomainException>(() => 
            order.ChangeDeliveryAddress("Новая 15", "Москва"));
    }
}