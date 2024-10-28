using AutoMapper;
using Microsoft.AspNetCore.Http;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Carts.DTO;
using PRM392_Backend.Service.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Carts
{
    public class CartService : ICartService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartService(IRepositoryManager repositoryManager,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
           this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        /// <summary>
        /// Lấy tất cả các giỏ hàng.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các giỏ hàng.</returns>
        public async Task<IEnumerable<Cart>> GetAllCartsAsync(bool trackChange = false)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await repositoryManager.CartRepository.GetCarts(userId,trackChange);
        }

        /// <summary>
        /// Lấy các giỏ hàng đang hoạt động.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các giỏ hàng hoạt động.</returns>
        public async Task<IEnumerable<Cart>> GetActiveCartsAsync(bool trackChange = false)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await repositoryManager.CartRepository.GetActiveCarts(userId,trackChange);
        }

        /// <summary>
        /// Lấy giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Đối tượng giỏ hàng hoặc null nếu không tìm thấy.</returns>
        public async Task<Cart?> GetCartByIdAsync(Guid id, bool trackChange = false)
        {
            return await repositoryManager.CartRepository.GetCartById(id, trackChange);
        }

        /// <summary>
        /// Tạo một giỏ hàng mới.
        /// </summary>
        /// <param name="cart">Đối tượng giỏ hàng cần tạo.</param>
        public async Task CreateCartAsync(CartRequestDTO cart)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Cart cartFinal = new Cart
            {
                UserID = userId,
                Status = CartStatus.Unpaid.ToString(),
                IsActive = true,
                TotalPrice =0.0,
            };
            
            repositoryManager.CartRepository.CreateCart(cartFinal);
            await repositoryManager.Save(); 
                    var total = 0.0;
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart), "Cart cannot be null.");
            }

            if (cart.Items == null || !cart.Items.Any())
            {
                throw new ArgumentException("Cart must contain at least one item.", nameof(cart.Items));
            }
            foreach (var item in cart.Items)
            {
                var product = await repositoryManager.ProductRepository.GetProductById(item.ProductID,true);
                CartItem cartItem = mapper.Map<CartItem>(item);
                cartItem.CartID = cartFinal.ID;
                cartItem.Price = product.Price * cartItem.Quantity;
                total += cartItem.Price;
                repositoryManager.CartItemRepository.CreateCartItem(cartItem);
                await repositoryManager.Save();
            }
            cartFinal.TotalPrice = total;
            
            repositoryManager.CartRepository.UpdateCart(cartFinal);
            await repositoryManager.Save();
        }

        /// <summary>
        /// Cập nhật thông tin giỏ hàng.
        /// </summary>
        /// <param name="cart">Đối tượng giỏ hàng cần cập nhật.</param>
        public async Task UpdateCartAsync(Cart cart)
        {
            repositoryManager.CartRepository.UpdateCart(cart);
            await repositoryManager.Save();
        }

        /// <summary>
        /// Xóa (soft delete) giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng cần xóa.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        public async Task DeleteCartAsync(Guid id, bool trackChange = false)
        {
            repositoryManager.CartRepository.DeleteCart(id, trackChange);
            await repositoryManager.Save();
        }

        /// <summary>
        /// Xóa (hard delete) giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng cần xóa.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        public async Task HardDeleteCartAsync(Guid id, bool trackChange = false)
        {
            repositoryManager.CartRepository.HardDeleteCart(id, trackChange);
            await repositoryManager.Save();
        }
    }
}
