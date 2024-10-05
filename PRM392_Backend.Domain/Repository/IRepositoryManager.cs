namespace PRM392_Backend.Domain.Repository
{
	public interface IRepositoryManager
	{
		ICategoryRepository CategoryRepository { get; }
		IStoreLocationRepository StoreLocationRepository { get; }
		Task Save();
	}
}
