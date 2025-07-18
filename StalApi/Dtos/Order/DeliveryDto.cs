namespace StalApi.Dtos.Order
{
    public class DeliveryDto
    {
        public Guid Id { get; set; }
        public Guid OrderItemId { get; set; }
        public int QuantityDelivered { get; set; }
        public DateTime ShippedAt { get; set; }
        public bool ConfirmedByClient { get; set; }
        public DateTime? ConfirmedAt { get; set; }
    }
}
