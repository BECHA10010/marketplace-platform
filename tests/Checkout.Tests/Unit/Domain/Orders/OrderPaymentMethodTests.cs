namespace Checkout.Tests.Unit.Domain.Orders;

public class OrderPaymentMethodTests
{
    [Fact]
    public void ChangePaymentMethod_ToBankTransfer_ShouldClearCardDetails()
    {
        var order = OrderTestFactory.CreateOrder();
        
        order.ChangePaymentMethod(PaymentMethod.BankTransfer);
        
        Assert.Equal(PaymentMethod.BankTransfer, order.PaymentMethod);
        Assert.Null(order.PaymentCard);
    }

    [Fact] public void ChangePaymentMethod_ToCreditCardWithCardDetails_ShouldUpdatePaymentMethod()
    {
        var order = OrderTestFactory.CreateOrder(PaymentMethod.BankTransfer);
        var cardDetails = OrderTestFactory.ValidCard();
        order.ChangeCreditCard(cardDetails.CardNumber, cardDetails.Expiration, cardDetails.CvvCode);
        
        order.ChangePaymentMethod(PaymentMethod.CreditCard);
        
        Assert.Equal(PaymentMethod.CreditCard, order.PaymentMethod);
    }
    
    [Fact]
    public void ChangePaymentMethod_ToCreditCardWithoutCardDetails_ShouldThrow()
    {
        var order = OrderTestFactory.CreateOrder(PaymentMethod.BankTransfer);

        Assert.Throws<DomainException>(() => 
            order.ChangePaymentMethod(PaymentMethod.CreditCard));
    }
    
    [Fact]
    public void ChangePaymentMethod_AfterPaymentCompleted_ShouldThrow()
    {
        var order = OrderTestFactory.CreateOrder();
        order.MarkPaymentCompleted();

        Assert.Throws<DomainException>(() =>
            order.ChangePaymentMethod(PaymentMethod.BankTransfer));
    }
}