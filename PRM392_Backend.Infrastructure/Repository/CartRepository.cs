using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Infrastructure.Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(DatabaseContext context) : base(context)
        {
        }

        /// <summary>
        /// Tạo một giỏ hàng mới.
        /// </summary>
        /// <param name="cart">Đối tượng giỏ hàng cần tạo.</param>
        public void CreateCart(Cart cart) => Create(cart);

        /// <summary>
        /// Lấy tất cả các giỏ hàng.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các giỏ hàng.</returns>
        public async Task<IEnumerable<Cart>> GetCarts(bool trackChange) =>
             await FindAll(trackChange)
          .Include(cart => cart.CartItems) // Tải CartItems
          .ThenInclude(cartItem => cartItem.Product) // Tải Product của từng CartItem
          .ToListAsync();
        /// <summary>
        /// Lấy các giỏ hàng đang hoạt động.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các giỏ hàng hoạt động.</returns>
        public async Task<IEnumerable<Cart>> GetActiveCarts(bool trackChange) =>
            await FindByCondition(x => x.IsActive, trackChange).Include(cart => cart.CartItems) // Tải CartItems
          .ThenInclude(cartItem => cartItem.Product) // Tải Product của từng CartItem
          .ToListAsync();

        /// <summary>
        /// Lấy giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Đối tượng giỏ hàng hoặc null nếu không tìm thấy.</returns>
        public async Task<Cart?> GetCartById(Guid? id, bool trackChange) =>
            await FindByCondition(x => x.ID == id, trackChange).Include(cart => cart.CartItems) // Tải CartItems
          .ThenInclude(cartItem => cartItem.Product).SingleOrDefaultAsync();

        /// <summary>
        /// Cập nhật thông tin giỏ hàng.
        /// </summary>
        /// <param name="cart">Đối tượng giỏ hàng cần cập nhật.</param>
        public void UpdateCart(Cart cart) => Update(cart);

        /// <summary>
        /// Xóa (soft delete) giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng cần xóa.</param>
        public void DeleteCart(Guid id, bool trackChange)
        {
            var cart = FindByCondition(x => x.ID == id, trackChange).SingleOrDefault();
            if (cart != null)
            {
                cart.IsActive = false; // Thực hiện soft delete
                Update(cart);
            }
        }
        public void HardDeleteCart(Guid id, bool trackChange)
        {
            var cart = FindByCondition(x => x.ID == id, trackChange).SingleOrDefault();
            if (cart != null)
            {
                Delete(cart); // Sử dụng phương thức Delete từ RepositoryBase để xóa thật sự
            }
        }
    }
}
