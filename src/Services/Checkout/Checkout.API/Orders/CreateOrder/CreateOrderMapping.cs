using Checkout.API.Orders.CreateOrder;
using Checkout.Application.Orders.Commands.CreateOrder;
using Checkout.Application.Orders.DTOs;
using Checkout.Domain.Order;

namespace Checkout.API.Features.Orders.CreateOrder;

public class CreateOrderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderRequest, CreateOrderCommand>()
            .Map(dest => dest.OrderData, src => new CreateOrderDto(
                src.AccountName,
                new ContactDto(src.ContactData.FirstName, src.ContactData.LastName, src.ContactData.Email),
                new AddressDto(src.AddressData.Street, src.AddressData.City),
                Enum.Parse<PaymentMethod>(src.PaymentMethod),
                src.CardData != null 
                    ? new CardDataDto(src.CardData.CardNumber, src.CardData.Expiration, src.CardData.CvvCode) 
                    : null,
                src.Items.Select(item => new OrderItemDto(item.CatalogItemName, item.Quantity, item.UnitPrice)).ToList()
            ));
    }
}