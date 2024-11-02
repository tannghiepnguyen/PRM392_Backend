using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Carts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Carts
{
    public interface ICartService
    {
        Task<IEnumerable<CartDTO>> GetAllCartsAsync(bool trackChange = false);
        Task<IEnumerable<CartDTO>> GetActiveCartsAsync(bool trackChange = false);
        Task<CartDTO?> GetCartByIdAsync(Guid id, bool trackChange = false);
        Task CreateCartAsync(CartRequestDTO cart);
        Task UpdateCartAsync(Guid id, CartRequestDTO cart);
        Task DeleteCartAsync(Guid id, bool trackChange = false);
        Task HardDeleteCartAsync(Guid id, bool trackChange = false);
    }
}
