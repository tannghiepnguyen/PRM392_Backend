using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.CartItems.DTO;
using PRM392_Backend.Service.Carts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.CartItems
{
    public interface ICartItemService
    {
      
        Task<IEnumerable<GetCartItemResponse>> GetAllCartItems(bool trackChange);
        Task<IEnumerable<GetCartItemResponse>> GetCartItemsByCartId(Guid cartId, bool trackChange);
        Task<GetCartItemResponse> GetCartItem(Guid id, bool trackChange);
        //Task UpdateCartItem(Guid id, CartItemForUpdateDto cartItemForUpdateDto, bool trackChange);
        Task DeleteCartItem(Guid id, bool trackChange);
        Task UpdateQuantityCartItem(CartItemForUpdateDTO cartItem);
    }
}
