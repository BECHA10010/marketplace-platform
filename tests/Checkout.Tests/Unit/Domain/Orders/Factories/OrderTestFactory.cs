namespace Checkout.Tests.Unit.Domain.Orders.Factories;

public static class OrderTestFactory
{
    public static List<OrderItem> ValidItems() =>
        new List<OrderItem>
        {
            new OrderItem("ProductA", 2, 10m)
        };
    
    public static Contact ValidContact() => 
        new Contact("Иван", "Николаевич", "ivan@gmail.com");
    
    public static DeliveryAddress ValidAddress() => 
        new DeliveryAddress("Ленинградская 12", "Уфа");
    
    public static CreditCard ValidCard() =>
        new CreditCard("4111111111111111", "12/30", "123");
    
    public static Order CreateOrder(PaymentMethod method = PaymentMethod.CreditCard, CreditCard? card = null)
    {
        return Order.Create(
            accountName: "test",
            contactInfo: ValidContact(),
            deliveryAddress: ValidAddress(),
            paymentMethod: method,
            cardDetails: card ?? (method == PaymentMethod.CreditCard ? ValidCard() : null),
            items: ValidItems()
        );
    }
}