using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;

namespace PRM392_Backend.Infrastructure.Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly DatabaseContext context;
		private readonly Lazy<ICategoryRepository> categoryRepository;
		private readonly Lazy<IStoreLocationRepository> storeLocationRepository;
		private readonly Lazy<IProductRepository> productRepository;

		public RepositoryManager(DatabaseContext databaseContext)
		{
			context = databaseContext;
			categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
			storeLocationRepository = new Lazy<IStoreLocationRepository>(() => new StoreLocationRepository(context));
			productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
		}
		public ICategoryRepository CategoryRepository => categoryRepository.Value;

		public IStoreLocationRepository StoreLocationRepository => storeLocationRepository.Value;

		public IProductRepository ProductRepository => productRepository.Value;

		public async Task Save() => await context.SaveChangesAsync();
	}
}
