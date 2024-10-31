using PRM392_Backend.Domain.Models;
using PRM392_Backend.Service.Orders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Orders
{
    public interface IOrderService
    {
        Task<OrderResponse> GetPendingOrder(bool trackChange);
        Task<Order?> GetOrder(Guid id, bool trackChange);
        Task<Order> CreateOrder(OrderRequestForCreate order);
        //Task UpdateOrder(Guid id, Order order, bool trackChange);
        Task UpdateOrder(Guid id, OrderStatus orderStatus);
        Task DeleteOrder(Guid id, bool trackChange);
        Task<IEnumerable<OrderResponse>> GetAllOrders(bool trackChange);
    }
}
