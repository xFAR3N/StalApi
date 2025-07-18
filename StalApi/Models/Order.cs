using System.ComponentModel.DataAnnotations.Schema;

namespace StalApi.Models
{
    public enum OrderStatus
    {
        Open,
        Closed
    }
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        [NotMapped]
        public User? Client {  get; set; }
        [NotMapped]
        public User? Supplier { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
