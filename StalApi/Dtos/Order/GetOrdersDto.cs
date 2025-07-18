using StalApi.Models;

namespace StalApi.Dtos.Order
{
    public class GetOrdersDto
    {
        public Guid Id { get; set; }
        public string ClientEmail { get; set; }
        public string SupplierEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

    }
}
