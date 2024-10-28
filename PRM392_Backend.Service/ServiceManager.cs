using PRM392_Backend.Service.IService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.CartItems;
using PRM392_Backend.Service.Carts;
using PRM392_Backend.Service.Categories;
using PRM392_Backend.Service.ChatMessages;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Orders;
using PRM392_Backend.Service.Payments;
using PRM392_Backend.Service.Products;
using PRM392_Backend.Service.StoreLocations;
using PRM392_Backend.Service.Users;
using PRM392_Backend.Service.Notifications;

namespace PRM392_Backend.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICategoryService _categoryService;
        private readonly IStoreLocationService _storeLocationService;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly IChatMessageService _chatMessageService;
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;

        public ServiceManager(IAuthenticationService authenticationService,
                              ICategoryService categoryService,
                              IStoreLocationService storeLocationService,
                              IProductService productService,
                              ICartService cartService,
                              ICartItemService cartItemService,
                              IOrderService orderService,
                              IChatMessageService chatMessageService,
                              IPaymentService paymentService,
                              INotificationService notificationService)
        {
            _authenticationService = authenticationService;
            _categoryService = categoryService;
            _storeLocationService = storeLocationService;
            _productService = productService;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _chatMessageService = chatMessageService;
            _paymentService = paymentService;
            _notificationService = notificationService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public ICategoryService CategoryService => _categoryService;
        public IStoreLocationService StoreLocationService => _storeLocationService;
        public IProductService ProductService => _productService;
        public ICartService CartService => _cartService;
        public ICartItemService CartItemService => _cartItemService;
        public IOrderService OrderService => _orderService;
        public IChatMessageService ChatMessageService => _chatMessageService;
        public IPaymentService PaymentService => _paymentService;
        public INotificationService NotificationService => _notificationService;
    }
} 