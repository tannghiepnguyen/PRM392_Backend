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
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.CartItems
{
    internal sealed class CartItemService : ICartItemService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public CartItemService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
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
            var cartItem = await repositoryManager.CartItemRepository.GetCartItemById(id, trackChange);
            if (cartItem == null) throw new CartItemNotFoundException(id);
            var total = 0.0;
            repositoryManager.CartItemRepository.HardDeleteCartItem(id, trackChange);
            await repositoryManager.Save();
            var cart = await repositoryManager.CartRepository.GetCartById(cartItem.CartID, trackChange);
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
            
            var total = 0.0;
            var cartItemExist = await repositoryManager.CartItemRepository.GetCartItemById(cartItem.ID, true);
            if (cartItemExist == null) throw new CartItemNotFoundException(cartItem.ID);
            cartItemExist.Quantity = cartItem.Quantity;
            repositoryManager.CartItemRepository.UpdateCartItem(cartItemExist);
            await repositoryManager.Save();
            var cart = await repositoryManager.CartRepository.GetCartById(cartItemExist.CartID,true);
            if (cart.UserID != cartItem.UserID.ToString())
            {
                throw new InvalidOperationException("You don't have permission to update the quantity of this item.");
            }

            foreach (var item in cart.CartItems)
            {
                total += item.Quantity * item.Price;
            }
            cart.TotalPrice = total;
            repositoryManager.CartRepository.UpdateCart(cart);
            await repositoryManager.Save();
        }
    }
}
