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
        public async Task<IEnumerable<Cart>> GetCarts(string accountID, bool trackChange) =>
            await FindByCondition(cart => cart.UserID == accountID.ToString(), trackChange)
                .Include(cart => cart.CartItems) // Tải CartItems
                .ThenInclude(cartItem => cartItem.Product) // Tải Product của từng CartItem
                .ToListAsync();

        /// <summary>
        /// Lấy các giỏ hàng đang hoạt động theo accountID.
        /// </summary>
        /// <param name="accountID">ID của tài khoản cần lọc giỏ hàng.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các giỏ hàng hoạt động.</returns>
        public async Task<IEnumerable<Cart>> GetActiveCarts(string accountID, bool trackChange) =>
            await FindByCondition(cart => cart.IsActive && cart.UserID == accountID.ToString(), trackChange)
                .Include(cart => cart.CartItems) // Tải CartItems
                .ThenInclude(cartItem => cartItem.Product) // Tải Product của từng CartItem
                .ToListAsync();

        public Cart? GetCartActiveAndUserId(string accountID, bool trackChange) =>
                FindByCondition(cart => cart.IsActive && cart.UserID == accountID.ToString(), trackChange)
                .Include(cart => cart.CartItems) 
                .ThenInclude(cartItem => cartItem.Product) 
                .FirstOrDefault(); 
       


        /// <summary>
        /// Lấy giỏ hàng theo ID.
        /// </summary>
        /// <param name="id">ID của giỏ hàng.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Đối tượng giỏ hàng hoặc null nếu không tìm thấy.</returns>
        public async Task<Cart?> GetCartById(Guid? id, bool trackChange) =>
            await FindByCondition(x => x.ID == id && x.IsActive, trackChange).Include(cart => cart.CartItems) // Tải CartItems
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
            var cart = FindByCondition(x => x.ID == id && x.IsActive, trackChange).SingleOrDefault();
            if (cart != null)
            {
                cart.IsActive = false; // Thực hiện soft delete
                Update(cart);
            }
        }
        public void HardDeleteCart(Guid id, bool trackChange)
        {
            var cart = FindByCondition(x => x.ID == id && x.IsActive, trackChange).SingleOrDefault();

            if (cart != null)
            {
                // Kiểm tra CartItems có null hay không trước khi xóa
                if (cart.CartItems != null)
                {
                    foreach (var cartItem in cart.CartItems.ToList()) 
                    {
                        _context.CartItems.Remove(cartItem);
                    }
                }

                // Sau khi xóa tất cả CartItems, xóa giỏ hàng
                Delete(cart);
            }
        }


        /// <summary>
        /// Lấy giỏ hàng đang hoạt động theo UserID.
        /// </summary>
        /// <param name="accountID">ID của tài khoản cần kiểm tra giỏ hàng.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Giỏ hàng đang hoạt động nếu có, ngược lại trả về null.</returns>
        public async Task<Cart?> GetSingleActiveCartByUserId(string accountID, bool trackChange)
        {
            return await FindByCondition(cart => cart.IsActive && cart.UserID == accountID, trackChange)
                .Include(cart => cart.CartItems) // Tải CartItems
                .ThenInclude(cartItem => cartItem.Product) // Tải Product của từng CartItem
                .FirstOrDefaultAsync();
        }
    }
}
