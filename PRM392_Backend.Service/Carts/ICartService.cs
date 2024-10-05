using PRM392_Backend.Domain.Models;
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
        Task CreateCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task DeleteCartAsync(Guid id, bool trackChange = false);
        Task HardDeleteCartAsync(Guid id, bool trackChange = false);
    }
}
