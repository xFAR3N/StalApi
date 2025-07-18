using StalApi.Dtos.Order;
using StalApi.Models;

namespace StalApi.Mappers
{
    public static class OrderMapper
    {
        public static GetOrdersDto ToOrdersDto(this Order o)
        {
            return new GetOrdersDto
            {
                Id = o.Id,
                ClientEmail = o.Client.email,
                SupplierEmail = o.Supplier.email,
                CreatedAt = o.CreatedAt,
                Status = o.Status.ToString()
            };
        }

        public static OrderDto GetOrderByIdDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Status = order.Status.ToString(),
                ClientEmail = order.Client?.email,
                SupplierEmail = order.Supplier?.email,
                Items = order.Items?.Select(i => new OrderItemDto
                {
                    Id = i.Id,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    Deliveries = i.Deliveries?.Select(d => new DeliveryDto
                    {
                        Id = d.Id,
                        QuantityDelivered = d.QuantityDelivered,
                        ShippedAt = d.ShippedAt,
                        ConfirmedByClient = d.ConfirmedByClient,
                        ConfirmedAt = d.ConfirmedAt
                    }).ToList()
                }).ToList()
            };
        }

    }
}
