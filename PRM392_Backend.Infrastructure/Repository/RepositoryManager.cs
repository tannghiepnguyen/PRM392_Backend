﻿using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;

namespace PRM392_Backend.Infrastructure.Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly DatabaseContext context;
		private readonly Lazy<ICategoryRepository> categoryRepository;
		private readonly Lazy<IStoreLocationRepository> storeLocationRepository;
		private readonly Lazy<IProductRepository> productRepository;
		private readonly Lazy<ICartRepository> cartRepository;
		private readonly Lazy<ICartItemRepository> itemRepository;
		public RepositoryManager(DatabaseContext databaseContext)
		{
			context = databaseContext;
			categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
			storeLocationRepository = new Lazy<IStoreLocationRepository>(() => new StoreLocationRepository(context));
			productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
			cartRepository = new Lazy<ICartRepository>(() => new CartRepository(context));
            itemRepository = new Lazy<ICartItemRepository>(() => new CartItemRepository(context));
		}
		public ICategoryRepository CategoryRepository => categoryRepository.Value;

		public IStoreLocationRepository StoreLocationRepository => storeLocationRepository.Value;

		public IProductRepository ProductRepository => productRepository.Value;
		public ICartRepository CartRepository => cartRepository.Value;
		public ICartItemRepository CartItemRepository => itemRepository.Value;
		public async Task Save() => await context.SaveChangesAsync();
	}
}
