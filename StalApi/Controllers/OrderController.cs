using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using StalApi.Data;
using StalApi.Dtos.Order;
using StalApi.Mappers;
using StalApi.Models;
using System.Linq;

namespace StalApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Order
            .Include(o => o.Client)
            .Include(o => o.Supplier)
            .ToListAsync();
            var orderDto = orders.Select(s => s.ToOrdersDto());

            return Ok(orderDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            var order = await _context.Order
            .Include(o => o.Client)
            .Include(o => o.Supplier)
            .Include(o => o.Items)
            .ThenInclude(d => d.Deliveries)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            var orderDto = order.GetOrderByIdDto();
            return Ok(orderDto);
        }
        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetOrdersForUser([FromRoute] Guid userId)
        {
            var orders = await _context.Order
            .Include(o => o.Client)
            .Include(o => o.Supplier)
            .Where(o => o.ClientId == userId || (o.SupplierId == userId && o.Status.Equals("Open")))
            .ToListAsync();

            var orderDto = orders.Select(s => s.ToOrdersDto());
            return Ok(orderDto);
        }
    }
}
