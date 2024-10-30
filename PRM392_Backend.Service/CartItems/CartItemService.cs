using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.CartItems.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.CartItems
{
    internal sealed class CartItemService : ICartItemService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartItemService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }



        public async Task<IEnumerable<CartItem>> GetAllCartItems(bool trackChange)
        {
            var cartItems = await repositoryManager.CartItemRepository.GetCartItems(trackChange);
            return cartItems;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId, bool trackChange)
        {
            var cartItems = await repositoryManager.CartItemRepository.GetCartItemsByCartId(cartId, trackChange);
            return cartItems;
        }

        public async Task<CartItem?> GetCartItem(Guid id, bool trackChange)
        {
            var cartItem = await repositoryManager.CartItemRepository.GetCartItemById(id, trackChange);
            if (cartItem == null) throw new CartItemNotFoundException(id);
            return cartItem;
        }
        public async Task DeleteCartItem(Guid id, bool trackChange)
        {
           
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cartItem = await repositoryManager.CartItemRepository.GetCartItemById(id, trackChange);
            var cart = await repositoryManager.CartRepository.GetCartById(cartItem.CartID, trackChange);
            if(cart.UserID != userId)
            {
                throw new InvalidOperationException("You don't have permission to update the quantity of this item.");
            }
            if (cartItem == null) throw new CartItemNotFoundException(id);
            var total = 0.0;
            repositoryManager.CartItemRepository.HardDeleteCartItem(id, trackChange);
            await repositoryManager.Save();
          
            if(cart.CartItems.Count == 0)
            {
                cart.IsActive = false;
            }
            foreach (var item in cart.CartItems)
            {
                total += item.Quantity * item.Price;
            }
            cart.TotalPrice = total;
            
            repositoryManager.CartRepository.UpdateCart(cart);
            await repositoryManager.Save();
        }
      
        public async Task UpdateQuantityCartItem(CartItemForUpdateDTO cartItem)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var total = 0.0;
            var cartItemExist = await repositoryManager.CartItemRepository.GetCartItemById(cartItem.ID, true);
            if (cartItemExist == null) throw new CartItemNotFoundException(cartItem.ID);
            if(cartItem.Quantity == 0)
            {
                repositoryManager.CartItemRepository.HardDeleteCartItem(cartItemExist.ID,true);
                await repositoryManager.Save();
            }
            else
            {
                cartItemExist.Quantity = cartItem.Quantity;
                repositoryManager.CartItemRepository.UpdateCartItem(cartItemExist);
                await repositoryManager.Save();
            }
            var cart = await repositoryManager.CartRepository.GetCartById(cartItemExist.CartID, true);
            if (cart.UserID != userId)
            {
                throw new InvalidOperationException("You don't have permission to update the quantity of this item.");
            }

           if(cart.CartItems.Count == 0)
           {
                repositoryManager.CartRepository.HardDeleteCart(cart.ID,true);
                await repositoryManager.Save();
           }
            else
            {
                foreach (var item in cart.CartItems)
                {
                    if (item.ProductID.HasValue)
                    {
                        var product = await repositoryManager.ProductRepository.GetProductById(item.ProductID.Value, true);
                        total += item.Quantity * product.Price;
                    }
                }
                cart.TotalPrice = total;
                repositoryManager.CartRepository.UpdateCart(cart);
                await repositoryManager.Save();
            }
        }
    }
}
