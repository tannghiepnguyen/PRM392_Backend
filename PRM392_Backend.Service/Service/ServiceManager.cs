﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Categories;
using PRM392_Backend.Service.IService;
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

		public ServiceManager(IRepositoryManager repositoryManager, UserManager<User> userManager, IConfiguration configuration, IMapper mapper, IBlobService blobService)
		{
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, mapper, configuration));
			categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
			storeLocationService = new Lazy<IStoreLocationService>(() => new StoreLocationService(repositoryManager, mapper));
			productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper, blobService));
		}
		public IAuthenticationService AuthenticationService => authenticationService.Value;

		public ICategoryService CategoryService => categoryService.Value;

		public IStoreLocationService StoreLocationService => storeLocationService.Value;

		public IProductService ProductService => productService.Value;
	}
}
