namespace Checkout.Domain.Entities;

public class Order : BaseEntity, IAggregateRoot
{
    private readonly List<OrderItem> _items = [];

    public string AccountName { get; private set; } = default!;
    public decimal TotalAmount => _items.Sum(i => i.UnitPrice * i.Quantity);
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    public OrderStatus CurrentOrderStatus { get; private set; }
    public Contact? ContactInfo { get; private set; }
    public Address? DeliveryAddress { get; private set; }
    public PaymentMethod CurrentPaymentMethod { get; private set; }
    public CardDetails? CardDetails { get; private set; }
    public PaymentStatus CurrentPaymentStatus { get; private set; }

    private Order() {}
    
    private Order(string accountName,
        Contact contactInfo,
        Address deliveryAddress,
        PaymentMethod paymentMethod,
        CardDetails? cardDetails,
        List<OrderItem> items)
    {
        AccountName = accountName;
        ContactInfo = contactInfo;
        DeliveryAddress = deliveryAddress;
        CurrentPaymentMethod = paymentMethod;
        CardDetails = cardDetails;

        CurrentOrderStatus = OrderStatus.Draft;
        CurrentPaymentStatus = PaymentStatus.Pending;
        
        _items = items;
    }

    public static Order Create(string accountName,
        Contact contactInfo,
        Address deliveryAddress,
        PaymentMethod paymentMethod,
        CardDetails? cardDetails,
        List<OrderItem> items)
    {
        if (paymentMethod == PaymentMethod.CreditCard && cardDetails is null)
            throw new DomainException("");
        
        var order = new Order(accountName, contactInfo, deliveryAddress, paymentMethod, cardDetails, items);
        
        return order;
    }

    public void ChangePaymentMethod(PaymentMethod newPaymentMethod)
    {
        if (CurrentPaymentStatus == PaymentStatus.Pending)
        {
            CurrentOrderStatus = OrderStatus.Paid;
        }
            
        CurrentPaymentMethod = newPaymentMethod;
    }
    
    public void ChangeDeliveryAddress(string street, string city)
    {
        DeliveryAddress = new Address(street, city);
    }
    
    public void ChangeCardData(string cardNumber, string expiration, string cvvCode)
    {
        CardDetails = new CardDetails(cardNumber, expiration, cvvCode);
    }
    
    public void ChangeContactData(string firstName, string lastName, string email)
    {
        ContactInfo = new Contact(firstName, lastName, email);
    }
}