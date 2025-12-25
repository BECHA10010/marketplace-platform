using Checkout.API.Orders.Common.Requests;
using Checkout.API.Orders.UpdateOrder;

namespace Checkout.Tests.TestData.Requests;

public static class UpdateOrderRequests
{
    public static UpdateOrderRequest ValidRequest_UpdateContactData() => 
        new(
            ContactData: new ContactDataRequest(
                FirstName: "Updated",
                LastName: "User",
                Email: "updated-user@mail.com"),
            AddressData: null,
            PaymentMethod: null,
            CardData: null
        );
    
    public static UpdateOrderRequest ValidRequest_UpdateAddressData() => 
        new(
            ContactData: null,
            AddressData: new AddressDataRequest(
                Street: "New Street 12",
                City: "UpdatedCity"),
            PaymentMethod: null,
            CardData: null
        );
    
    public static UpdateOrderRequest ValidRequest_UpdatePaymentMethodToBankTransfer() => 
        new(
            ContactData: null,
            AddressData: null,
            PaymentMethod: "BankTransfer",
            CardData: null
        );
    
    public static UpdateOrderRequest ValidRequest_UpdatePaymentMethodToCreditCard() => 
        new(
            ContactData: null,
            AddressData: null,
            PaymentMethod: "CreditCard",
            CardData: new CardDataRequest(
                CardNumber: "1111222233334444",
                Expiration: "12/30",
                CvvCode: "123")
        );
    
    public static UpdateOrderRequest ValidRequest_UpdateCardDetails() => 
        new(
            ContactData: null,
            AddressData: null,
            PaymentMethod: null,
            CardData: new CardDataRequest(
                CardNumber: "5555666677778888",
                Expiration: "11/29",
                CvvCode: "321")
        );
    
    public static UpdateOrderRequest ValidRequest_UpdateEverything() => 
        new(
            ContactData: new ContactDataRequest("John", "Doe", "new@mail.com"),
            AddressData: new AddressDataRequest("Updated st", "UpdatedCity"),
            PaymentMethod: "CreditCard",
            CardData: new CardDataRequest("4444333322221111", "10/28", "999")
        );
    
    public static UpdateOrderRequest InvalidRequest_UpdateToInvalidPaymentMethod() => 
        new(
            ContactData: null,
            AddressData: null,
            PaymentMethod: "Invalid",
            CardData: new CardDataRequest(
                CardNumber: "1234123412341234",
                Expiration: "01/30",
                CvvCode: "111")
        );
}