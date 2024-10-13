using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders(bool trackChange);
        Task<Order?> GetOrderById(Guid id, bool trackChange);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
