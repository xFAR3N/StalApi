using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StalApi.Data;
using StalApi.Dtos.Order;
using StalApi.Mappers;
using StalApi.Models;

namespace StalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DeliveriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeliveries()
        {
            var deliveries = await _context.Delivery.ToListAsync();

            var deliveriesDto = deliveries.Select(p => p.ToDeliveryDto());
            return Ok(deliveriesDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDeliveryById([FromRoute] Guid Id)
        {
            var delivery = await _context.Delivery.FindAsync(Id);
            if (delivery == null)
            {
                return NotFound();
            }
            var deliveryDto = delivery.ToDeliveryDto();

            return Ok(deliveryDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDelivery([FromBody] DeliveryDto dto)
        {
            var orderItem = await _context.OrderItem
                .Include(o => o.Deliveries)
                .Include(o => o.Order)
                .FirstOrDefaultAsync( o=> o.Id == dto.OrderItemId);
            var delivery = new Delivery
            {
                Id = Guid.NewGuid(),
                OrderItemId = dto.Id,
                QuantityDelivered = dto.QuantityDelivered,
                ShippedAt = dto.ShippedAt,
                ConfirmedByClient = dto.ConfirmedByClient,
                ConfirmedAt = dto.ConfirmedAt
            };

            _context.Delivery.Add(delivery);
            await _context.SaveChangesAsync();
            var deliveryDto = delivery.ToDeliveryDto();
            return Ok(deliveryDto);
        }
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> ConfirmDelivery([FromRoute] Guid id)
        {
            var delivery = await _context.Delivery.FindAsync(id);
            if(delivery == null)
            {
                return NotFound();
            }
            delivery.ConfirmedByClient = true;
            delivery.ConfirmedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
