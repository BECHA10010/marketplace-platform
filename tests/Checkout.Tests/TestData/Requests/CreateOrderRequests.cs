namespace Checkout.Tests.TestData.Requests;

public static class CreateOrderRequests
{
    public static CreateOrderRequest ValidRequest_CreateWithCreditCard() =>
        new(
            AccountName: "test_user",
            ContactData: new ContactDataRequest("John", "Doe", "john@doe.com"),
            AddressData: new AddressDataRequest("Street 1", "City"),
            PaymentMethod: "CreditCard",
            CardData: new CardDataRequest("1234567890123456", "12/30", "123"),
            Items: 
            [
                new OrderItemRequest("Product 1", 1, 100)
            ]
        );
    
    public static CreateOrderRequest ValidRequest_CreateWithBankTransfer() =>
        new(
            AccountName: "test",
            ContactData: new ContactDataRequest("John", "Doe", "john@doe.com"),
            AddressData: new AddressDataRequest("Street 1", "City"),
            PaymentMethod: "BankTransfer",
            CardData: null,
            Items: 
            [
                new OrderItemRequest("Product 1", 1, 100)
            ]
        );
    
    public static CreateOrderRequest InvalidRequest_CreateWithCardPaymentWithoutDetails() =>
        new(
            AccountName: "test_user",
            ContactData: new ContactDataRequest("John", "Doe", "john@doe.com"),
            AddressData: new AddressDataRequest("Street 1", "City"),
            PaymentMethod: "CreditCard",
            CardData: null,
            Items: 
            [
                new OrderItemRequest("Product 1", 1, 100)
            ]
        );

    public static CreateOrderRequest InvalidRequest_CreateWithBankTransferAndCardDetails() =>
        new(
            AccountName: "test_user",
            ContactData: new ContactDataRequest("John", "Doe", "john@doe.com"),
            AddressData: new AddressDataRequest("Street 1", "City"),
            PaymentMethod: "BankTransfer",
            CardData: new CardDataRequest("1234567890123456", "12/30", "123"),
            Items: 
            [
                new OrderItemRequest("Product 1", 1, 100)
            ]
        );
    
    public static CreateOrderRequest InvalidRequest_CreateWithEmptyItems() =>
        new(
            AccountName: "test_user",
            ContactData: new ContactDataRequest("John", "Doe", "john@doe.com"),
            AddressData: new AddressDataRequest("Street 1", "City"),
            PaymentMethod: "BankTransfer",
            CardData: null,
            Items: []
        );
}