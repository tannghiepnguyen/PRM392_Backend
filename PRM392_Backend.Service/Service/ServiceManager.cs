﻿using AutoMapper;
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
using PRM392_Backend.Service.Products;
using PRM392_Backend.Service.StoreLocations;
using PRM392_Backend.Service.Users;

namespace PRM392_Backend.Service.Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IAuthenticationService> authenticationService;
		private readonly Lazy<ICategoryService> categoryService;
		private readonly Lazy<IStoreLocationService> storeLocationService;
		private readonly Lazy<IProductService> productService;
		private readonly Lazy<ICartService> cartService;
		private readonly Lazy<ICartItemService> cartItemService;
		private readonly Lazy<IOrderService> orderService;
		private readonly Lazy<IChatMessageService> chatMessageService;
		public ServiceManager(IRepositoryManager repositoryManager, UserManager<User> userManager, IConfiguration configuration, IMapper mapper, IBlobService blobService, IHttpContextAccessor _httpContextAccessor)
		{
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, mapper, configuration));
			categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
			storeLocationService = new Lazy<IStoreLocationService>(() => new StoreLocationService(repositoryManager, mapper));
			productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper, blobService));
			cartService = new Lazy<ICartService>(()=> new CartService(repositoryManager,mapper,_httpContextAccessor));
			cartItemService = new Lazy<ICartItemService>(() => new CartItemService(repositoryManager, mapper,_httpContextAccessor));
			orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, mapper));	
			chatMessageService = new Lazy<IChatMessageService>(()=> new ChatMessageService(repositoryManager, mapper,_httpContextAccessor));	
		}
		public IAuthenticationService AuthenticationService => authenticationService.Value;

		public ICategoryService CategoryService => categoryService.Value;

		public IStoreLocationService StoreLocationService => storeLocationService.Value;

		public IProductService ProductService => productService.Value;
		public ICartService CartService => cartService.Value;
		public ICartItemService CartItemService => cartItemService.Value;	
		public IOrderService OrderService => orderService.Value;
		public IChatMessageService ChatMessageService => chatMessageService.Value;
	}
}
