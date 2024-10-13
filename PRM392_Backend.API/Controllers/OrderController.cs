using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Orders;
using PRM392_Backend.Service.Orders.DTO;
using PRM392_Backend.Service.Service;

namespace PRM392_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public OrdersController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }


        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] bool trackChange)
        {
            var orders = await serviceManager.OrderService.GetOrders(trackChange);
            return Ok(orders);
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id, [FromQuery] bool trackChange)
        {
            var order = await serviceManager.OrderService.GetOrder(id, trackChange);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromForm] OrderRequestForCreate orderForCreationDto)
        {
            var order = await serviceManager.OrderService.CreateOrder(orderForCreationDto);
            return CreatedAtAction(nameof(GetOrder), new { id = order.ID }, order);
        }




        // PUT: api/Orders/{id}
        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, OrderStatus orderStatus)
        {
            try
            {
                await serviceManager.OrderService.UpdateOrder(id, orderStatus);
                return NoContent();
            }
            catch (OrderNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            try
            {
                await serviceManager.OrderService.DeleteOrder(id, true);
                return NoContent();
            }
            catch (OrderNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
