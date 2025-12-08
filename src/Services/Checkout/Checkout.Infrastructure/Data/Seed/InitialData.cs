namespace Checkout.Infrastructure.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Order> Orders =>
    [
        Order.Create
        (
            "test_account",
            new Contact("Иван", "Иванов", "ivan@test.com"),
            new DeliveryAddress("Ленина 1", "Москва"),
            PaymentMethod.CreditCard,
            new CreditCard("4111111111111111", "12/25", "123"),
            new List<OrderItem>()
            {
                new OrderItem("Мультиварка Redmond RMC-M90", 1, 5890m),
                new OrderItem("Бюджетный смартфон с хорошей камерой", 1, 7990m),
                new OrderItem("Фен Polaris PHD 2077", 1, 1790m)
            }
            
            
            //CurrentOrderStatus = OrderStatus.Paid,
            //CurrentPaymentStatus = PaymentStatus.Completed,
        ),
        Order.Create
        (
            "admin@example.com",
            new Contact("Анна", "Петрова", "anna@example.com"),
            new DeliveryAddress("Тверская 12", "Москва"),
            PaymentMethod.BankTransfer,
            null,
            new List<OrderItem>
            {
                new OrderItem("Кофеварка Polaris PCM 1516E", 1, 3290m)
            }
            
            //CurrentOrderStatus = OrderStatus.Submitted,
            //CurrentPaymentStatus = PaymentStatus.Pending,
        )
    ];
}