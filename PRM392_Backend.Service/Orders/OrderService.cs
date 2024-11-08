using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Carts.DTO;
using PRM392_Backend.Service.Orders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Orders
{
   
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<OrderResponse> GetPendingOrder (bool trackChange)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var order =  await repositoryManager.OrderRepository.GetPendingOrdersByAccountID(userId,false);
            return mapper.Map<OrderResponse>(order);
        }
        public async Task<IEnumerable<OrderResponse>> GetAllOrders(bool trackChange)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orders = await repositoryManager.OrderRepository.GetOrdersByAccountID(userId, false);
            return mapper.Map<IEnumerable<OrderResponse>>(orders);
        }

        public async Task<Order?> GetOrder(Guid id, bool trackChange)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var order = await repositoryManager.OrderRepository.GetOrderByIdAndUserId(id,userId, trackChange);
            if (order == null) throw new OrderNotFoundException(id);
            return order;
        }

        public async Task<Order> CreateOrder(OrderRequestForCreate orderDTO)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Order order= mapper.Map<Order>(orderDTO);
            order.UserID = userId;
            order.OrderStatus = OrderStatus.Pending.ToString() ;
            order.PaymentMethod = orderDTO.PaymentMethod.ToString() ;
            var cartExist = await repositoryManager.CartRepository.GetCartById(order.CartID,true);
            if(cartExist == null)
            {
                throw new InvalidOperationException("This cart isn't exist");
            }
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
            try
            {
                await repositoryManager.Save();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                // Nếu có thêm thông tin cụ thể về entity gặp lỗi
                foreach (var entry in ex.Entries)
                {
                    Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
                }

                throw;
            }

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
