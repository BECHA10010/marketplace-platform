using Checkout.Domain.Order;

namespace Checkout.Tests.Unit.Domain.Orders;

public class OrderCustomerContactTests
{
    [Theory]
    [InlineData(OrderStatus.Submitted)]
    [InlineData(OrderStatus.Paid)]
    [InlineData(OrderStatus.Draft)]
    public void ChangeCustomerContact_WhenStatusIsSupported_ShouldUpdateContact(OrderStatus status)
    {
        var order = TestOrderFactory.CreateValidOrder();
        order.SetOrderStatus(status);
        
        order.ChangeCustomerContact("Николай", "Максимов", "nick@gmail.com");
        
        Assert.Equal("Николай", order.CustomerContact?.FirstName);
        Assert.Equal("Максимов", order.CustomerContact?.LastName);
        Assert.Equal("nick@gmail.com", order.CustomerContact?.Email);
    }
    
    [Theory]
    [InlineData(OrderStatus.Shipped)]
    [InlineData(OrderStatus.Cancelled)]
    public void ChangeCustomerContact_WhenStatusIsUnsupported_ShouldThrow(OrderStatus status)
    {
        var order = TestOrderFactory.CreateValidOrder();
        order.SetOrderStatus(status);

        Assert.Throws<DomainException>(() => 
            order.ChangeCustomerContact("Николай", "Максимов", "nick@gmail.com"));
    }
}