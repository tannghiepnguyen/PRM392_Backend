using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface ICartItemRepository
    {
        void CreateCartItem(CartItem cartItem);
        Task<IEnumerable<CartItem>> GetCartItems(bool trackChange);
        Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId, bool trackChange);
        Task<CartItem?> GetCartItemById(Guid id, bool trackChange);
        void UpdateCartItem(CartItem cartItem);
 
        void HardDeleteCartItem(Guid id, bool trackChange);
    }
}
