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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrders(bool trackChange) =>
            await FindAll(trackChange).ToListAsync();

        /// <summary>
        /// Lấy các đơn hàng theo AccountID.
        /// </summary>
        /// <param name="accountID">ID của tài khoản cần lọc.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các đơn hàng của tài khoản chỉ định.</returns>
        public async Task<IEnumerable<Order>> GetOrdersByAccountID(string accountID, bool trackChange) =>
            await FindByCondition(order => order.UserID == accountID.ToString(), trackChange)
             .Include(order => order.Cart)
                .ThenInclude(cart => cart.CartItems)
                .ThenInclude(cartitems => cartitems.Product)
            .Include(order => order.User)
            .Include(order => order.StoreLocation)
                .ThenInclude(store => store.Store)
            .ToListAsync();

        /// <summary>
        /// Lấy các đơn hàng theo trạng thái và OrderID.
        /// </summary>
        /// <param name="status">Trạng thái của đơn hàng cần lọc.</param>
        /// <param name="orderID">ID của đơn hàng cần lọc.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Danh sách các đơn hàng với trạng thái và OrderID chỉ định.</returns>
        //public async Task<Order?> GetOrdersByStatusAndUserID(string status, string UserId, bool trackChange) =>
        //    await FindByCondition(order => order.OrderStatus == status && order.UserID == UserId, trackChange)
        //        .FirstOrDefaultAsync();


        public async Task<Order?> GetPendingOrdersByAccountID(string accountID, bool trackChange) =>
         FindByCondition(order => order.UserID == accountID.ToString() && order.OrderStatus == OrderStatus.Pending.ToString(), trackChange)
         .Include(order => order.Cart)
            .ThenInclude(cart => cart.CartItems)
            .ThenInclude(cartitems => cartitems.Product)
        .Include(order => order.User)
        .Include(order => order.StoreLocation)
        .FirstOrDefault();

        public Order? GetPendingOrderAndUserId(string userId, bool trackChange) =>
             FindByCondition(order => order.UserID == userId.ToString() &&  order.OrderStatus == OrderStatus.Pending.ToString(), trackChange)
            .Include(order => order.Cart)
                .ThenInclude(cart => cart.CartItems)
                .ThenInclude(cartitems => cartitems.Product)
            .Include(order => order.User)
            .FirstOrDefault();


        public async Task<Order?> GetOrderById(Guid id, bool trackChange) =>
            await FindByCondition(x => x.ID == id, trackChange).SingleOrDefaultAsync();

        /// <summary>
        /// Lấy đơn hàng theo ID và UserID.
        /// </summary>
        /// <param name="id">ID của đơn hàng cần tìm.</param>
        /// <param name="userId">ID của người dùng cần kiểm tra.</param>
        /// <param name="trackChange">Có theo dõi thay đổi hay không.</param>
        /// <returns>Đơn hàng nếu tìm thấy, ngược lại trả về null.</returns>
        public async Task<Order?> GetOrderByIdAndUserId(Guid id, string userId, bool trackChange) =>
            await FindByCondition(x => x.ID == id && x.UserID == userId, trackChange).SingleOrDefaultAsync();

        public void CreateOrder(Order order) => Create(order);

        public void UpdateOrder(Order order) => Update(order);

        public void DeleteOrder(Order order) => Delete(order);

        
    }
}
