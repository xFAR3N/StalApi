namespace StalApi.Dtos.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string ClientEmail { get; set; }
        public string SupplierEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
