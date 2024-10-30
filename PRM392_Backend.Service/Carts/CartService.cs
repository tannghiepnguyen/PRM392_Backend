using AutoMapper;
using Microsoft.AspNetCore.Http;
using PRM392_Backend.Domain.Exceptions;
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

            // Check for an existing active cart
            var existingCart = await repositoryManager.CartRepository.GetSingleActiveCartByUserId(userId, true);
            if (existingCart != null)
            {
                await UpdateCartAsync(existingCart.ID, cart);
                return;
            }

            // Create a new cart if none exists
            var newCart = new Cart
            {
                UserID = userId,
                Status = CartStatus.Unpaid.ToString(),
                IsActive = true,
                TotalPrice = 0.0,
            };

            repositoryManager.CartRepository.CreateCart(newCart);
            await repositoryManager.Save();

            if (cart?.Items == null || !cart.Items.Any())
            {
                throw new ArgumentException("Cart must contain at least one item.", nameof(cart.Items));
            }

            double total = await AddCartItemsToCartAsync(cart.Items, newCart.ID);
            newCart.TotalPrice = total;

            repositoryManager.CartRepository.UpdateCart(newCart);
            await repositoryManager.Save();
        }

        public async Task UpdateCartAsync(Guid id, CartRequestDTO cart)
        {
            var cartExist = await repositoryManager.CartRepository.GetCartById(id, true)
                            ?? throw new CartNotFoundException(id);

            if (cart?.Items == null || !cart.Items.Any())
            {
                throw new ArgumentException("Cart must contain at least one item.", nameof(cart.Items));
            }

            foreach (var item in cart.Items)
            {
                var product = await repositoryManager.ProductRepository.GetProductById(item.ProductID, true)
                              ?? throw new ProductNotFoundException(item.ProductID);

                var existingCartItem = cartExist.CartItems.FirstOrDefault(ci => ci.ProductID == item.ProductID);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += item.Quantity;
                    existingCartItem.Price = product.Price * existingCartItem.Quantity;
                }
                else
                {
                    var newCartItem = mapper.Map<CartItem>(item);
                    newCartItem.CartID = cartExist.ID;
                    newCartItem.Price = product.Price * newCartItem.Quantity;
                    cartExist.CartItems.Add(newCartItem);
                }
            }

            cartExist.TotalPrice = cartExist.CartItems.Sum(ci => ci.Price);

            repositoryManager.CartRepository.UpdateCart(cartExist);
            await repositoryManager.Save();
        }

        private async Task<double> AddCartItemsToCartAsync(IEnumerable<CartItemRequestDTO> items, Guid cartId)
        {
            double total = 0.0;

            foreach (var item in items)
            {
                var product = await repositoryManager.ProductRepository.GetProductById(item.ProductID, true)
                              ?? throw new ProductNotFoundException(item.ProductID);

                var cartItem = mapper.Map<CartItem>(item);
                cartItem.CartID = cartId;
                cartItem.Price = product.Price * cartItem.Quantity;
                total += cartItem.Price;

                repositoryManager.CartItemRepository.CreateCartItem(cartItem);
            }

            await repositoryManager.Save();
            return total;
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
