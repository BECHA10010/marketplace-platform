namespace Checkout.Tests.Domain.Orders;

public class OrderCustomerContactTests
{
    private static List<OrderItem> ValidItems() => 
    [
        new ("ProductA", 2, 10m)
    ];
    
    private static Contact ValidContact() => 
        new ("Иван", "Николаевич", "ivan@gmail.com");
    
    private static DeliveryAddress ValidAddress() => 
        new ("Северная 12", "Вологда");
    
    private static CreditCard ValidCard() =>
        new("4111111111111111", "12/30", "123");
    
    private static Order CreateOrder()
    {
        return Order.Create(
            accountName: "johndoe",
            contactInfo: ValidContact(),
            deliveryAddress: ValidAddress(),
            paymentMethod: PaymentMethod.CreditCard,
            cardDetails: ValidCard(),
            items: ValidItems()
        );
    }
    
    public static IEnumerable<object[]> NotShippedStatuses() =>
        new List<object[]>
        {
            new object[] { OrderStatus.Submitted },
            new object[] { OrderStatus.Paid },
            new object[] { OrderStatus.Draft },
            new object[] { OrderStatus.Cancelled }
        };
    
    [Theory]
    [MemberData(nameof(NotShippedStatuses))]
    public void ChangeCustomerContact_WhenNotShippedStatus_ShouldUpdateContact(OrderStatus status)
    {
        var order = CreateOrder();
        order.SetOrderStatus(status);
        
        order.ChangeCustomerContact("Николай", "Максимов", "nick@gmail.com");
        
        Assert.Equal(status, order.Status);
    }
    
    [Fact]
    public void ChangeCustomerContact_InShippedStatus_ShouldThrow()
    {
        var order = CreateOrder();
        order.SetOrderStatus(OrderStatus.Shipped);

        Assert.Throws<DomainException>(() => 
            order.ChangeCustomerContact("Николай", "Максимов", "nick@gmail.com"));
    }
}