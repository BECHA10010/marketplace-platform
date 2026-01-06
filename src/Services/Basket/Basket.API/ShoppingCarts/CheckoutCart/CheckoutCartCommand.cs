namespace Basket.API.ShoppingCarts.CheckoutCart;

public record CheckoutCartCommand(
    Guid CorrelationId,
    string AccountName,
    CustomerContactDto Contact,
    CustomerAddressDto Address,
    PaymentDetailsDto Payment
) : ICommand<CheckoutCartResult>;

public record CustomerContactDto(
    string FirstName,
    string LastName,
    string Email
);

public record CustomerAddressDto(
    string Street,
    string City
);

public record PaymentDetailsDto(
    string Method,
    string? CardNumber,
    string? Expiration,
    string? CvvCode
);