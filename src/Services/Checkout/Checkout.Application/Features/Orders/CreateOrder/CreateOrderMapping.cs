using Checkout.Application.Features.Orders.CreateOrder;

namespace Checkout.Application.Orders.Mappings;

public class CreateOrderMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        /*config.NewConfig<CreateOrderDto, Order>()
            .Map(o => o.CurrentPaymentMethod, src => src.PaymentMethod)
            .Map(o => o.CardDetails, src
                => src.CardDetails != null
                    ? src.CardDetails.Adapt<CardDetails>()
                    : null)
            .Map(o => o.TotalAmount, src => src.TotalPrice) // формирование из товаров
            .Map(o => o.ContactInfo, src => src.ContactInfo.Adapt<Contact>())
            .Map(o => o.DeliveryAddress, src => src.DeliveryAddress.Adapt<Address>())
            .Map(o => o.Items, src 
                => src.Items.Select(item => new OrderItemDto(
                    item.CatalogItemName,
                    item.Quantity,
                    item.UnitPrice)));*/

        /*config.NewConfig<OrderItemDto, OrderItem>();

        config.NewConfig<ContactDto, Contact>()
            .ConstructUsing(c => new Contact(c.FirstName + "###", c.LastName, c.Email));*/
    }
}