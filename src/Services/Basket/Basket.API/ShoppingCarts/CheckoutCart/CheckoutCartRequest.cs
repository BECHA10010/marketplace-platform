namespace Basket.API.ShoppingCarts.CheckoutCart;

public record CheckoutCartRequest(
    string AccountName,
    CustomerContactRequest Contact,
    CustomerAddressRequest Address,
    PaymentDetailsRequest Payment
);

public record CustomerContactRequest(
    string FirstName,
    string LastName,
    string Email
);

public record CustomerAddressRequest(
    string Street,
    string City
);

public record PaymentDetailsRequest(
    string Method,
    string? CardNumber,
    string? Expiration,
    string? CvvCode
);