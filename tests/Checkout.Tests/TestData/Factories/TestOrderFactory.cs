using Checkout.Domain.Order;

namespace Checkout.Tests.TestData.Factories;

public static class TestOrderFactory
{
    public static string ValidAccountName => "TestOrderAccount";
    
    public static Contact ValidUserContact() => new("Иван", "Николаевич", "ivan@gmail.com");
    
    public static DeliveryAddress ValidDeliveryAddress() => new("Ленинградская 12", "Уфа");
    
    public static CreditCard ValidCardDetails() => new("4111111111111111", "12/30", "123");
    
    public static List<OrderItem> ValidOrderItems() =>
    [
        new($"Product {Guid.NewGuid()}", 2, 10m)
    ];
    
    public static Order CreateValidOrder(PaymentMethod method = PaymentMethod.CreditCard, CreditCard? card = null)
    {
        return Order.Create(
            accountName: ValidAccountName,
            contactInfo: ValidUserContact(),
            deliveryAddress: ValidDeliveryAddress(),
            paymentMethod: method,
            cardDetails: card ?? (method == PaymentMethod.CreditCard ? ValidCardDetails() : null),
            items: ValidOrderItems()
        );
    }
}