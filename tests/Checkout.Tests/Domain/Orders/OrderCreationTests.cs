namespace Checkout.Tests.Domain.Orders;

public class OrderCreationTests
{
    private static List<OrderItem> CreateValidItems() => 
    [
        new ("ProductA", 2, 10m)
    ];
    
    private static Contact CreateValidContact() => 
        new ("Иван", "Николаевич", "ivan@gmail.com");
    
    private static DeliveryAddress CreateValidAddress() => 
        new ("Северная 12", "Вологда");
    
    private static CreditCard CreateValidCard()
        => new("4111111111111111", "12/30", "123");
    
    [Fact]
    public void Create_WithValidData_ShouldCreateOrder()
    {
        var order = Order.Create(
            accountName: "johndoe",
            contactInfo: CreateValidContact(),
            deliveryAddress: CreateValidAddress(),
            paymentMethod: PaymentMethod.CreditCard,
            cardDetails: CreateValidCard(),
            items: CreateValidItems()
        );
        
        Assert.Equal("johndoe", order.AccountName);
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
                accountName: "johndoe",
                contactInfo: CreateValidContact(),
                deliveryAddress: CreateValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: null,
                items: CreateValidItems()
            ));
    }

    [Fact]
    public void Create_WithBankTransferAndCardDetails_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "johndoe",
                contactInfo: CreateValidContact(),
                deliveryAddress: CreateValidAddress(),
                paymentMethod: PaymentMethod.BankTransfer,
                cardDetails: CreateValidCard(),
                items: CreateValidItems()
            ));
    }
    
    [Fact]
    public void Create_WithoutItems_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "johndoe",
                contactInfo: CreateValidContact(),
                deliveryAddress: CreateValidAddress(),
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
            new ("ProductA", 0, 10m)
        };
        
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "johndoe",
                contactInfo: CreateValidContact(),
                deliveryAddress: CreateValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: CreateValidCard(),
                items: invalidItems
            ));
    }
    
    [Fact]
    public void Create_WithInvalidItemUnitPrice_ShouldThrow()
    {
        var invalidItems = new List<OrderItem>
        {
            new ("ProductA", 5, 0m)
        };
        
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "johndoe",
                contactInfo: CreateValidContact(),
                deliveryAddress: CreateValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: CreateValidCard(),
                items: invalidItems
            ));
    }
    
    [Fact]
    public void Create_WithItemsAndWithoutDeliveryAddress_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "johndoe",
                contactInfo: CreateValidContact(),
                deliveryAddress: null!,
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: CreateValidCard(),
                items: CreateValidItems()
            ));
    }
    
    [Fact]
    public void Create_WithoutCustomerContact_ShouldThrow()
    {
        Assert.Throws<DomainException>(() => 
            Order.Create(
                accountName: "johndoe",
                contactInfo: null!,
                deliveryAddress: CreateValidAddress(),
                paymentMethod: PaymentMethod.CreditCard,
                cardDetails: CreateValidCard(),
                items: CreateValidItems()
            ));
    }
}