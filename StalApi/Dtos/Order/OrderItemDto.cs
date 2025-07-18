namespace StalApi.Dtos.Order
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public List<DeliveryDto> Deliveries { get; set; } = new();
    }
}
