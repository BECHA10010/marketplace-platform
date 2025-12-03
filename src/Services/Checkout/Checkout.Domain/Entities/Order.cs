namespace Checkout.Domain.Entities;

public class Order : BaseEntity, IAggregateRoot
{
    private readonly List<OrderItem> _items = [];

    public string AccountName { get; private set; } = default!;
    public decimal TotalAmount => _items.Sum(i => i.UnitPrice * i.Quantity);
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    public OrderStatus Status { get; private set; }
    public Contact? CustomerContact { get; private set; }
    public DeliveryAddress? DeliveryAddress { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public CreditCard? PaymentCard { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }

    private Order() {}
    
    private Order(string accountName,
        Contact? contactInfo,
        DeliveryAddress? deliveryDeliveryAddress,
        PaymentMethod paymentMethod,
        CreditCard? cardDetails,
        List<OrderItem> items)
    {
        AccountName = accountName;
        CustomerContact = contactInfo;
        DeliveryAddress = deliveryDeliveryAddress;
        PaymentMethod = paymentMethod;
        PaymentCard = cardDetails;

        Status = OrderStatus.Draft;
        PaymentStatus = PaymentStatus.Pending;
        
        _items = items;
    }

    public static Order Create(string accountName,
        Contact? contactInfo,
        DeliveryAddress? deliveryAddress,
        PaymentMethod paymentMethod,
        CreditCard? cardDetails,
        List<OrderItem> items)
    {
        if (paymentMethod == PaymentMethod.CreditCard && cardDetails is null)
            throw new DomainException("Card details are required for credit card payments.");

        if (paymentMethod == PaymentMethod.BankTransfer && cardDetails is not null)
            throw new DomainException("Card details must not be provided for bank transfer payments.");

        if (items is null || items.Count == 0)
            throw new DomainException("Order must contain at least one item.");
        
        if (items.Count > 0 && deliveryAddress is null)
            throw new DomainException("Delivery address is required when the order contains items.");
        
        if (items.Any(i => i.Quantity <= 0))
            throw new DomainException("Quantity must be greater than zero.");

        if (items.Any(i => i.UnitPrice <= 0))
            throw new DomainException("Unit price must be greater than zero.");
        
        if (contactInfo is null)
            throw new DomainException("Contact information is required.");
        
        return new Order(accountName, contactInfo, deliveryAddress, paymentMethod, cardDetails, items);
    }
    
    public void ChangePaymentMethod(PaymentMethod newMethod)
    {
        if (PaymentStatus == PaymentStatus.Completed)
            throw new DomainException("Cannot change payment method after payment is completed.");
        
        if (newMethod == PaymentMethod.CreditCard && PaymentCard is null)
            throw new DomainException("Card details must be provided before switching to credit card.");

        if (newMethod == PaymentMethod.BankTransfer)
            PaymentCard = null;
        
        PaymentMethod = newMethod;
    }
    
    public void ChangeDeliveryAddress(string street, string city)
    {
        if (Status != OrderStatus.Draft)
            throw new DomainException("Delivery address cannot be changed after order submission.");
        
        DeliveryAddress = new DeliveryAddress(street, city);
    }
    
    public void ChangeCreditCard(string cardNumber, string expiration, string cvvCode)
    {
        if (Status is OrderStatus.Shipped or OrderStatus.Cancelled)
            throw new DomainException($"Cannot modify card details after {Status}.");
        
        PaymentCard = new CreditCard(cardNumber, expiration, cvvCode);
    }
    
    public void ChangeCustomerContact(string firstName, string lastName, string email)
    {
        if (Status is OrderStatus.Shipped or OrderStatus.Cancelled)
            throw new DomainException($"Cannot modify customer contact after {Status}.");
        
        CustomerContact = new Contact(firstName, lastName, email);
    }
    
    public void Cancel()
    {
        if (Status is OrderStatus.Shipped or OrderStatus.Cancelled)
            throw new DomainException($"Cannot cancel a {Status} order.");
        
        Status = OrderStatus.Cancelled;
    }
    
    public void MarkPaymentCompleted()
    {
        PaymentStatus = PaymentStatus.Completed;
        Status = OrderStatus.Paid;
    }
}