namespace Checkout.Tests.Domain.Orders;

public class OrderPaymentMethodTests
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

    private static Order CreateOrder(PaymentMethod method, CreditCard? card = null)
    {
        return Order.Create(
            accountName: "johndoe",
            contactInfo: ValidContact(),
            deliveryAddress: ValidAddress(),
            paymentMethod: method,
            cardDetails: card,
            items: ValidItems()
        );
    }
    
    [Fact]
    public void ChangePaymentMethod_ToCreditCardWithoutCardDetails_ShouldThrow()
    {
        var order = CreateOrder(PaymentMethod.BankTransfer);

        Assert.Throws<DomainException>(() => 
            order.ChangePaymentMethod(PaymentMethod.CreditCard));
    }
    
    [Fact]
    public void ChangePaymentMethod_ToBankTransfer_ShouldClearCardDetails()
    {
        var order = CreateOrder(PaymentMethod.CreditCard, ValidCard());
        
        order.ChangePaymentMethod(PaymentMethod.BankTransfer);
        
        Assert.Equal(PaymentMethod.BankTransfer, order.PaymentMethod);
        Assert.Null(order.PaymentCard);
    }
    
    [Fact]
    public void ChangePaymentMethod_AfterPaymentCompleted_ShouldThrow()
    {
        var order = CreateOrder(PaymentMethod.CreditCard, ValidCard());
        order.MarkPaymentCompleted();

        Assert.Throws<DomainException>(() =>
            order.ChangePaymentMethod(PaymentMethod.BankTransfer));
    }
    
    [Fact]
    public void ChangePaymentMethod_ToValidMethod_ShouldUpdatePaymentMethod()
    {
        var order = CreateOrder(PaymentMethod.CreditCard, ValidCard());
        
        order.ChangePaymentMethod(PaymentMethod.BankTransfer);
        
        Assert.Equal(PaymentMethod.BankTransfer, order.PaymentMethod);
    }
}