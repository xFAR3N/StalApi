namespace StalApi.Models
{
    public class Delivery
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderItemId { get; set; }
        public OrderItem? OrderItem { get; set; }
        public int QuantityDelivered {  get; set; }
        public DateTime ShippedAt { get; set; }
        public bool ConfirmedByClient { get; set; } = false;
        public DateTime? ConfirmedAt { get; set; }

    }
}
