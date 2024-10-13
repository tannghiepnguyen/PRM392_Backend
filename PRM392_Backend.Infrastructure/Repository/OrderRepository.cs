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

        public async Task<Order?> GetOrderById(Guid id, bool trackChange) =>
            await FindByCondition(x => x.ID == id, trackChange).SingleOrDefaultAsync();

        public void CreateOrder(Order order) => Create(order);

        public void UpdateOrder(Order order) => Update(order);

        public void DeleteOrder(Order order) => Delete(order);
    }
}
