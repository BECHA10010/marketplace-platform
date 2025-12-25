using Checkout.Domain.Order;

namespace Checkout.Tests.Unit.Domain.Orders;

public class OrderCancelTests
{
    [Theory]
    [InlineData(OrderStatus.Submitted)]
    [InlineData(OrderStatus.Paid)]
    [InlineData(OrderStatus.Draft)]
    public void Cancel_WhenStatusIsSupported_ShouldCancelled(OrderStatus status)
    {
        var order = TestOrderFactory.CreateValidOrder();
        order.SetOrderStatus(status);
        
        order.Cancel();
        
        Assert.Equal(OrderStatus.Cancelled, order.Status);
    }
    
    [Theory]
    [InlineData(OrderStatus.Shipped)]
    [InlineData(OrderStatus.Cancelled)]
    public void Cancel_WhenStatusIsUnsupported_ShouldThrow(OrderStatus status)
    {
        var order = TestOrderFactory.CreateValidOrder();
        order.SetOrderStatus(status);
        
        Assert.Throws<DomainException>(() => 
            order.Cancel());
    }
}