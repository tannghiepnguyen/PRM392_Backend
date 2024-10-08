﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Carts;
using PRM392_Backend.Service.Carts.DTO;
using PRM392_Backend.Service.IService;

namespace PRM392_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public CartController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }


        /// <summary>
        /// Lấy tất cả các giỏ hàng.
        /// </summary>
        /// <returns>Danh sách các giỏ hàng.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            try
            {
                var carts = await serviceManager.CartService.GetAllCartsAsync();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần
                return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy các giỏ hàng đang hoạt động.
        /// </summary>
        /// <returns>Danh sách các giỏ hàng hoạt động.</returns>
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCarts()
        {
            try
            {
                var carts = await serviceManager.CartService.GetActiveCartsAsync();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần
                return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng.</param>
        /// <returns>Đối tượng giỏ hàng hoặc NotFound nếu không tìm thấy.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(Guid id)
        {
            try
            {
                var cart = await serviceManager.CartService.GetCartByIdAsync(id);
                if (cart == null)
                    return NotFound($"Không tìm thấy giỏ hàng với ID: {id}");

                return Ok(cart);
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần
                return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Tạo một giỏ hàng mới.
        /// </summary>
        /// <param name="cart">Đối tượng giỏ hàng cần tạo.</param>
        /// <returns>Giỏ hàng đã được tạo.</returns>
        [HttpPost]
     
        public async Task<IActionResult> CreateCart([FromBody] CartRequestDTO cart)
        {
            if (cart == null)
                return BadRequest("Giỏ hàng không được để trống.");

            // Kiểm tra các thuộc tính bắt buộc
          

            try
            {
                await serviceManager.CartService.CreateCartAsync(cart);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần
                return StatusCode(500, $"Đã xảy ra lỗi khi tạo giỏ hàng: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật thông tin giỏ hàng.
        /// </summary>
        /// <param name="id">ID của giỏ hàng cần cập nhật.</param>
        /// <param name="updatedCart">Đối tượng giỏ hàng đã được cập nhật.</param>
        /// <returns>NoContent nếu cập nhật thành công hoặc NotFound nếu không tìm thấy.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(Guid id, [FromBody] Cart updatedCart)
        {
            if (updatedCart == null || id != updatedCart.ID)
                return BadRequest("Dữ liệu giỏ hàng không hợp lệ.");

            try
            {
                var existingCart = await serviceManager.CartService.GetCartByIdAsync(id);
                if (existingCart == null)
                    return NotFound($"Không tìm thấy giỏ hàng với ID: {id}");

                // Cập nhật các thuộc tính cần thiết
                existingCart.TotalPrice = updatedCart.TotalPrice;
                existingCart.Status = updatedCart.Status;
                existingCart.CartItems = updatedCart.CartItems;
                existingCart.UserID = updatedCart.UserID;
                existingCart.Order = updatedCart.Order;
                existingCart.IsActive = updatedCart.IsActive;

                await serviceManager.CartService.UpdateCartAsync(existingCart);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần
                return StatusCode(500, $"Đã xảy ra lỗi khi cập nhật giỏ hàng: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa (soft delete) giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng cần xóa.</param>
        /// <returns>NoContent nếu xóa thành công hoặc NotFound nếu không tìm thấy.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            try
            {
                var existingCart = await serviceManager.CartService.GetCartByIdAsync(id);
                if (existingCart == null)
                    return NotFound($"Không tìm thấy giỏ hàng với ID: {id}");

                await serviceManager.CartService.DeleteCartAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần
                return StatusCode(500, $"Đã xảy ra lỗi khi xóa giỏ hàng: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa (hard delete) giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng cần xóa.</param>
        /// <returns>NoContent nếu xóa thành công hoặc NotFound nếu không tìm thấy.</returns>
        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDeleteCart(Guid id)
        {
            try
            {
                var existingCart = await serviceManager.CartService.GetCartByIdAsync(id);
                if (existingCart == null)
                    return NotFound($"Không tìm thấy giỏ hàng với ID: {id}");

                await serviceManager.CartService.HardDeleteCartAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần
                return StatusCode(500, $"Đã xảy ra lỗi khi xóa giỏ hàng (hard delete): {ex.Message}");
            }
        }
    }
}
