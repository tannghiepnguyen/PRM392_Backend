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
        Task<IEnumerable<Order>> GetOrders(bool trackChange);
        Task<Order?> GetOrder(Guid id, bool trackChange);
        Task<Order> CreateOrder(OrderRequestForCreate order);
        //Task UpdateOrder(Guid id, Order order, bool trackChange);
        Task DeleteOrder(Guid id, bool trackChange);
    }
}
