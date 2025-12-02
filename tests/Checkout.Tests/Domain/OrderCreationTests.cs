namespace Checkout.Tests.Domain;

public class OrderCreationTests
{
    [Fact]
    public void CreateOrder_ShouldSucceed_WhenValidDataProvided()
    {
        var contact = new Contact("John", "Doe", "john@mail.com");
        var address = new DeliveryAddress("Main St", "New York");

        var items = new List<OrderItem>
        {
            new OrderItem("ProductA", 2, 10m)
        };

        var card = new CreditCard("1111222233334444", "12/30", "123");
        
        var order = Order.Create(
            accountName: "johndoe",
            contactInfo: contact,
            deliveryAddress: address,
            paymentMethod: PaymentMethod.CreditCard,
            cardDetails: card,
            items: items
        );
        
        Assert.Equal("johndoe", order.AccountName);
        Assert.Equal(20m, order.TotalAmount);
        Assert.Equal(OrderStatus.Draft, order.Status);
        Assert.Equal(PaymentStatus.Pending, order.PaymentStatus);
        Assert.Single(order.Items);
        Assert.NotNull(order.PaymentCard);
    }
}