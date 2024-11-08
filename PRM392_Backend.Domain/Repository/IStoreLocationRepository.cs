using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Domain.Repository
{
	public interface IStoreLocationRepository
	{
		Task<IEnumerable<StoreLocation>> GetStoreLocations(bool trackChange);
		Task<IEnumerable<StoreLocation>> GetActiveStoreLocations(bool trackChange);
		Task<StoreLocation?> GetStoreLocationByStoreId(Guid storeId, bool trackChange);
        Task<StoreLocation?> GetStoreLocationById(Guid id, bool trackChange);
        void CreateStoreLocation(StoreLocation storeLocation);
	}
}
