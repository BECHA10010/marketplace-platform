using Checkout.Domain.Order;

namespace Checkout.Tests.Unit.Domain.Orders;

public class OrderCreationTests
{
    [Fact]
    public void Create_WithValidData_ShouldCreateOrder()
    {
        var order = TestOrderFactory.CreateValidOrder();
        
        Assert.Equal(TestOrderFactory.ValidAccountName, order.AccountName);
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
                contactInfo: TestOrderFactory.ValidUserContact(),
                deliveryAddress: TestOrderFactory.ValidDeliveryAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: null,
                items: TestOrderFactory.ValidOrderItems()
            ));
    }

    [Fact]
    public void Create_WithBankTransferAndCardDetails_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: TestOrderFactory.ValidUserContact(),
                deliveryAddress: TestOrderFactory.ValidDeliveryAddress(),
                paymentMethod: PaymentMethod.BankTransfer,
                cardDetails: TestOrderFactory.ValidCardDetails(),
                items: TestOrderFactory.ValidOrderItems()
            ));
    }
    
    [Fact]
    public void Create_WithoutItems_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: TestOrderFactory.ValidUserContact(),
                deliveryAddress: TestOrderFactory.ValidDeliveryAddress(),
                paymentMethod: PaymentMethod.BankTransfer,
                cardDetails: null,
                items: []
            ));
    }
    
    [Fact]
    public void Create_WithInvalidItemQuantity_ShouldThrow()
    {
        var invalidItems = new List<OrderItem>
        {
            new("ProductA", 0, 10m)
        };
        
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: TestOrderFactory.ValidUserContact(),
                deliveryAddress: TestOrderFactory.ValidDeliveryAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: TestOrderFactory.ValidCardDetails(),
                items: invalidItems
            ));
    }
    
    [Fact]
    public void Create_WithInvalidItemUnitPrice_ShouldThrow()
    {
        var invalidItems = new List<OrderItem>
        {
            new("ProductA", 5, 0m)
        };
        
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: TestOrderFactory.ValidUserContact(),
                deliveryAddress: TestOrderFactory.ValidDeliveryAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: TestOrderFactory.ValidCardDetails(),
                items: invalidItems
            ));
    }
    
    [Fact]
    public void Create_WithItemsAndWithoutDeliveryAddress_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: TestOrderFactory.ValidUserContact(),
                deliveryAddress: null,
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: TestOrderFactory.ValidCardDetails(),
                items: TestOrderFactory.ValidOrderItems()
            ));
    }
    
    [Fact]
    public void Create_WithoutCustomerContact_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "test",
                contactInfo: null,
                deliveryAddress: TestOrderFactory.ValidDeliveryAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: TestOrderFactory.ValidCardDetails(),
                items: TestOrderFactory.ValidOrderItems()
            ));
    }
}