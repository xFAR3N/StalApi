using StalApi.Dtos.Order;
using StalApi.Models;

namespace StalApi.Mappers
{
    public static class DeliveryMapper
    {
        public static DeliveryDto ToDeliveryDto(this Delivery deliveryDto)
        {
            return new DeliveryDto
            {
                Id = deliveryDto.Id,
                OrderItemId = deliveryDto.OrderItemId,
                QuantityDelivered = deliveryDto.QuantityDelivered,
                ShippedAt = deliveryDto.ShippedAt,
                ConfirmedByClient = deliveryDto.ConfirmedByClient,
                ConfirmedAt = deliveryDto.ConfirmedAt
            };
        }
    }
}
