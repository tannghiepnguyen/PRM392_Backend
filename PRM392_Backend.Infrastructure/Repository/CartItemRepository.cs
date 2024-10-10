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
    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        public CartItemRepository(DatabaseContext context) : base(context)
        {
        }

        /// <summary>
        /// Tạo một mục giỏ hàng mới.
        /// </summary>
        /// <param name="cartItem">Đối tượng mục giỏ hàng cần tạo.</param>
        public void CreateCartItem(CartItem cartItem) => Create(cartItem);

        /// <summary>
        /// Lấy tất cả các mục giỏ hàng.
        /// </summary>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các mục giỏ hàng.</returns>
        public async Task<IEnumerable<CartItem>> GetCartItems(bool trackChange) =>
            await FindAll(trackChange).ToListAsync();

        /// <summary>
        /// Lấy các mục giỏ hàng theo giỏ hàng ID.
        /// </summary>
        /// <param name="cartId">ID của giỏ hàng.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các mục giỏ hàng theo giỏ hàng ID.</returns>
        public async Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId, bool trackChange) =>
            await FindByCondition(x => x.CartID == cartId, trackChange).ToListAsync();

        /// <summary>
        /// Lấy mục giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của mục giỏ hàng.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Đối tượng mục giỏ hàng hoặc null nếu không tìm thấy.</returns>
        public async Task<CartItem?> GetCartItemById(Guid id, bool trackChange) =>
            await FindByCondition(x => x.ID == id, trackChange).SingleOrDefaultAsync();

        /// <summary>
        /// Cập nhật thông tin mục giỏ hàng.
        /// </summary>
        /// <param name="cartItem">Đối tượng mục giỏ hàng cần cập nhật.</param>
        public void UpdateCartItem(CartItem cartItem) => Update(cartItem);

        /// <summary>
        /// Xóa (soft delete) mục giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của mục giỏ hàng cần xóa.</param>
        //public void DeleteCartItem(Guid id, bool trackChange)
        //{
        //    var cartItem = FindByCondition(x => x.ID == id, trackChange).SingleOrDefault();
        //    if (cartItem != null)
        //    {
        //        cartItem. = false; // Thực hiện soft delete
        //        Update(cartItem);
        //    }
        //}
        public void HardDeleteCartItem(Guid id, bool trackChange)
        {
            var cartItem = FindByCondition(x => x.ID == id, trackChange).SingleOrDefault();
            if (cartItem != null)
            {
                Delete(cartItem); // Sử dụng phương thức Delete từ RepositoryBase để xóa thật sự
            }
        }
    }
}
