namespace PRM392_Backend.Domain.Repository
{
	public interface IRepositoryManager
	{
		ICategoryRepository CategoryRepository { get; }
		IStoreLocationRepository StoreLocationRepository { get; }
		IProductRepository ProductRepository { get; }
		ICartRepository CartRepository { get; }
		Task Save();
	}
}
