namespace Checkout.Tests.Domain.Orders;

public class OrderDeliveryAddressTests
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
    
    [Fact]
    public void ChangeDeliveryAddress_InDraftStatus_ShouldUpdateAddress()
    {
        var order = CreateOrder();
        
        order.ChangeDeliveryAddress("Новая 15", "Москва");
        
        Assert.Equal("Новая 15", order.DeliveryAddress!.Street);
        Assert.Equal("Москва", order.DeliveryAddress!.City);
    }
    
    public static IEnumerable<object[]> NotDraftStatuses() =>
        new List<object[]>
        {
            new object[] { OrderStatus.Submitted },
            new object[] { OrderStatus.Paid },
            new object[] { OrderStatus.Shipped },
            new object[] { OrderStatus.Cancelled }
        };
    
    [Theory]
    [MemberData(nameof(NotDraftStatuses))]
    public void ChangeDeliveryAddress_WhenNotDraftStatus_ShouldThrow(OrderStatus status)
    {
        var order = CreateOrder();
        order.SetOrderStatus(status);

        Assert.Throws<DomainException>(() => 
            order.ChangeDeliveryAddress("Новая 15", "Москва"));
    }
}