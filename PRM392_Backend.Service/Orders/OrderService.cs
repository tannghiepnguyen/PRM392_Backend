using AutoMapper;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Orders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Orders
{
   
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Order>> GetOrders(bool trackChange)
        {
            var orders = await repositoryManager.OrderRepository.GetOrders(trackChange);
            return orders;
        }

        public async Task<Order?> GetOrder(Guid id, bool trackChange)
        {
            var order = await repositoryManager.OrderRepository.GetOrderById(id, trackChange);
            if (order == null) throw new OrderNotFoundException(id);
            return order;
        }

        public async Task<Order> CreateOrder(OrderRequestForCreate orderDTO)
        {
            Order order= mapper.Map<Order>(orderDTO);
            order.OrderStatus = OrderStatus.Processing.ToString() ;
            order.PaymentMethod = orderDTO.PaymentMethod.ToString() ;
            var cartExist = await repositoryManager.CartRepository.GetCartById(order.CartID,true);
            if(cartExist.IsActive == false)
            {
                throw new InvalidOperationException("This cart is InActive");
            }
            if(cartExist.UserID != order.UserID)
            {
                throw new InvalidOperationException("You don't have permission to create this order.");
            }
            var storeLocationExist = await repositoryManager.StoreLocationRepository.GetStoreLocationById(orderDTO.StoreLocationID,true);
            repositoryManager.OrderRepository.CreateOrder(order);
            await repositoryManager.Save();

            return order;
        }

        public async Task UpdateOrder(Guid id, OrderStatus orderStatus)
        {
            var existingOrder = await repositoryManager.OrderRepository.GetOrderById(id,true);
            if (existingOrder == null) throw new OrderNotFoundException(id);

            existingOrder.OrderStatus = orderStatus.ToString();
            repositoryManager.OrderRepository.UpdateOrder(existingOrder);
            await repositoryManager.Save();
        }

        public async Task DeleteOrder(Guid id, bool trackChange)
        {
            var order = await repositoryManager.OrderRepository.GetOrderById(id, trackChange);
            if (order == null) throw new OrderNotFoundException(id);

            repositoryManager.OrderRepository.DeleteOrder(order);
            await repositoryManager.Save();
        }
    }
}
