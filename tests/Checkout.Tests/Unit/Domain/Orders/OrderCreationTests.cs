namespace Checkout.Tests.Unit.Domain.Orders;

public class OrderCreationTests
{
    [Fact]
    public void Create_WithValidData_ShouldCreateOrder()
    {
        var order = OrderTestFactory.CreateOrder();
        
        Assert.Equal("test", order.AccountName);
        Assert.Equal(20m, order.TotalAmount);
        Assert.Equal(OrderStatus.Draft, order.Status);
        Assert.Equal(PaymentStatus.Pending, order.PaymentStatus);
        Assert.Single(order.Items);
        Assert.NotNull(order.PaymentCard);
    }

    [Fact]
    public void Create_WithCreditCardPaymentWithoutCardDetails_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: OrderTestFactory.ValidContact(),
                deliveryAddress: OrderTestFactory.ValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: null,
                items: OrderTestFactory.ValidItems()
            ));
    }

    [Fact]
    public void Create_WithBankTransferAndCardDetails_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: OrderTestFactory.ValidContact(),
                deliveryAddress: OrderTestFactory.ValidAddress(),
                paymentMethod: PaymentMethod.BankTransfer,
                cardDetails: OrderTestFactory.ValidCard(),
                items: OrderTestFactory.ValidItems()
            ));
    }
    
    [Fact]
    public void Create_WithoutItems_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: OrderTestFactory.ValidContact(),
                deliveryAddress: OrderTestFactory.ValidAddress(),
                paymentMethod: PaymentMethod.BankTransfer,
                cardDetails: null,
                items: new List<OrderItem>()
            ));
    }
    
    [Fact]
    public void Create_WithInvalidItemQuantity_ShouldThrow()
    {
        var invalidItems = new List<OrderItem>
        {
            new OrderItem("ProductA", 0, 10m)
        };
        
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: OrderTestFactory.ValidContact(),
                deliveryAddress: OrderTestFactory.ValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: OrderTestFactory.ValidCard(),
                items: invalidItems
            ));
    }
    
    [Fact]
    public void Create_WithInvalidItemUnitPrice_ShouldThrow()
    {
        var invalidItems = new List<OrderItem>
        {
            new OrderItem("ProductA", 5, 0m)
        };
        
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: OrderTestFactory.ValidContact(),
                deliveryAddress: OrderTestFactory.ValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: OrderTestFactory.ValidCard(),
                items: invalidItems
            ));
    }
    
    [Fact]
    public void Create_WithItemsAndWithoutDeliveryAddress_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: OrderTestFactory.ValidContact(),
                deliveryAddress: null,
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: OrderTestFactory.ValidCard(),
                items: OrderTestFactory.ValidItems()
            ));
    }
    
    [Fact]
    public void Create_WithoutCustomerContact_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: null,
                deliveryAddress: OrderTestFactory.ValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: OrderTestFactory.ValidCard(),
                items: OrderTestFactory.ValidItems()
            ));
    }
}