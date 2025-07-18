﻿namespace StalApi.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public List<Delivery> Deliveries { get; set; } = new();
    }
}
