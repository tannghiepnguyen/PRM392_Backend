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
        Task<IEnumerable<Cart>> GetAllCartsAsync(bool trackChange = false);
        Task<IEnumerable<Cart>> GetActiveCartsAsync(bool trackChange = false);
        Task<Cart?> GetCartByIdAsync(Guid id, bool trackChange = false);
        Task CreateCartAsync(CartRequestDTO cart);
        Task UpdateCartAsync(Guid id, CartRequestDTO cart);
        Task DeleteCartAsync(Guid id, bool trackChange = false);
        Task HardDeleteCartAsync(Guid id, bool trackChange = false);
    }
}
