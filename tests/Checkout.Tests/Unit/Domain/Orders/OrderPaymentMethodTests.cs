using Checkout.Domain.Order;

namespace Checkout.Tests.Unit.Domain.Orders;

public class OrderPaymentMethodTests
{
    [Fact]
    public void ChangePaymentMethod_ToBankTransfer_ShouldClearCardDetails()
    {
        var order = TestOrderFactory.CreateValidOrder();
        
        order.ChangePaymentMethod(PaymentMethod.BankTransfer);
        
        Assert.Equal(PaymentMethod.BankTransfer, order.PaymentMethod);
        Assert.Null(order.PaymentCard);
    }

    [Fact] public void ChangePaymentMethod_ToCreditCardWithCardDetails_ShouldUpdatePaymentMethod()
    {
        var order = TestOrderFactory.CreateValidOrder(PaymentMethod.BankTransfer);
        var cardDetails = TestOrderFactory.ValidCardDetails();
        order.ChangeCreditCard(cardDetails.CardNumber, cardDetails.Expiration, cardDetails.CvvCode);
        
        order.ChangePaymentMethod(PaymentMethod.CreditCard);
        
        Assert.Equal(PaymentMethod.CreditCard, order.PaymentMethod);
    }
    
    [Fact]
    public void ChangePaymentMethod_ToCreditCardWithoutCardDetails_ShouldThrow()
    {
        var order = TestOrderFactory.CreateValidOrder(PaymentMethod.BankTransfer);

        Assert.Throws<DomainException>(() => 
            order.ChangePaymentMethod(PaymentMethod.CreditCard));
    }
    
    [Fact]
    public void ChangePaymentMethod_AfterPaymentCompleted_ShouldThrow()
    {
        var order = TestOrderFactory.CreateValidOrder();
        order.MarkPaymentCompleted();

        Assert.Throws<DomainException>(() =>
            order.ChangePaymentMethod(PaymentMethod.BankTransfer));
    }
}