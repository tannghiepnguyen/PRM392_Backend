using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Service.CartItems;
using PRM392_Backend.Service.CartItems.DTO;
using PRM392_Backend.Service.IService;

namespace PRM392_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public CartItemController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }



        // GET: api/CartItems
            [HttpGet]
            public async Task<IActionResult> GetAllCartItems()
            {
                var cartItems = await serviceManager.CartItemService.GetAllCartItems(true);
                return Ok(cartItems);
            }

            // GET: api/CartItems/byCartId/{cartId}
            [HttpGet("byCartId/{cartId}")]
            public async Task<IActionResult> GetCartItemsByCartId(Guid cartId, [FromQuery] bool trackChange)
            {
                var cartItems = await serviceManager.CartItemService.GetCartItemsByCartId(cartId, trackChange);
                return Ok(cartItems);
            }

            // GET: api/CartItems/{id}
            [HttpGet("{id}")]
            public async Task<IActionResult> GetCartItem(Guid id, [FromQuery] bool trackChange)
            {
                var cartItem = await serviceManager.CartItemService.GetCartItem(id, trackChange);
                if (cartItem == null)
                {
                    return NotFound();
                }
                return Ok(cartItem);
            }


            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCartItem(Guid id, [FromQuery] bool trackChange)
            {   
                try
                {
                await serviceManager.CartItemService.DeleteCartItem(id, trackChange);
                return NoContent();
                }
                catch (CartItemNotFoundException)
                {
                return NotFound();
                }
        }
        // PUT: api/CartItems/{id}
        [HttpPut("quantity")]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartItemForUpdateDTO cartItemForUpdateDto)
        {
            try
            {
                await serviceManager.CartItemService.UpdateQuantityCartItem(cartItemForUpdateDto);
                return NoContent();
            }
            catch (CartItemNotFoundException)
            {
                return NotFound();
            }

        }
    }
    
}
