namespace Checkout.API.Orders.Requests;

public record UpdateOrderRequest(
    ContactDataRequest? ContactData,
    AddressDataRequest? AddressData,
    string? PaymentMethod,
    CardDataRequest? CardData
);

public record ContactDataRequest(string FirstName, string LastName, string Email);

public record CardDataRequest(string CardNumber, string Expiration, string CvvCode);

public record AddressDataRequest(string Street, string City);