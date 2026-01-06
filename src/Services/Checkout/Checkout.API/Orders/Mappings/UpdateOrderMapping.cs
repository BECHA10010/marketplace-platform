namespace Checkout.API.Orders.Mappings;

public static class UpdateOrderMapping
{
    public static UpdateOrderDto ToDto(this UpdateOrderRequest request)
    {
        return new UpdateOrderDto(
            ContactData: request.ContactData is null
                ? null
                : new CustomerContactDto(
                    request.ContactData.FirstName,
                    request.ContactData.LastName,
                    request.ContactData.Email),
            
            AddressData: request.AddressData is null
                ? null
                : new CustomerAddressDto(
                    request.AddressData.Street,
                    request.AddressData.City),
            
            PaymentMethod: request.PaymentMethod is null
                ? null
                : Enum.Parse<PaymentMethod>(request.PaymentMethod),
            
            CardData: request.CardData is null
                ? null
                : new CardDetailsDto(
                    request.CardData.CardNumber,
                    request.CardData.Expiration,
                    request.CardData.CvvCode)
        );
    }
}