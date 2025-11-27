namespace Checkout.Application.Orders.Mappings;

public class GetOrdersByAccountNameMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        /*config.NewConfig<Order, OrderDto>()
            .Map(dest => dest.OrderStatus, src => src.CurrentOrderStatus.ToString())
            .Map(dest => dest.PaymentMethod, src => src.CurrentPaymentMethod.ToString())
            .Map(dest => dest.PaymentStatus, src => src.CurrentPaymentStatus.ToString())
            .Map(dest => dest.TotalPrice, src => src.TotalAmount)
            .Map(dest => dest.PaymentDetails, src 
                => src.CardDetails != null 
                    ? new GetOrdersPaymentDetailsDto(src.CardDetails.CardName,
                        MaskCardNumber(src.CardDetails.CardNumber),
                        src.CardDetails.Expiration)
                    : null)
            .Map(dest => dest.Items, src => src.Items.Select(item => 
                new OrderItemDto(
                    item.CatalogItemName,
                    item.Quantity,
                    item.UnitPrice)));

        config.NewConfig<Contact, ContactDto>();
        config.NewConfig<Address, AddressDto>();*/
    }

    private static string MaskCardNumber(string cardNumber)
    {
        if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 4)
            return cardNumber;

        return $"####-{cardNumber[^4..]}";
    }
}