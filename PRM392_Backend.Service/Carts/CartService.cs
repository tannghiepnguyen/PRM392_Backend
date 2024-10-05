using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Carts
{
    public class CartService : ICartService
    {
        private readonly IRepositoryManager repositoryManager;

        public CartService(IRepositoryManager repositoryManager)
        {
           this.repositoryManager = repositoryManager;
        }

        /// <summary>
        /// Lấy tất cả các giỏ hàng.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các giỏ hàng.</returns>
        public async Task<IEnumerable<Cart>> GetAllCartsAsync(bool trackChange = false)
        {
            return await repositoryManager.CartRepository.GetCarts(trackChange);
        }

        /// <summary>
        /// Lấy các giỏ hàng đang hoạt động.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các giỏ hàng hoạt động.</returns>
        public async Task<IEnumerable<Cart>> GetActiveCartsAsync(bool trackChange = false)
        {
            return await repositoryManager.CartRepository.GetActiveCarts(trackChange);
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
        public async Task CreateCartAsync(Cart cart)
        {
            repositoryManager.CartRepository.CreateCart(cart);
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
