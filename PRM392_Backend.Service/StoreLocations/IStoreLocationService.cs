using PRM392_Backend.Service.StoreLocations.DTO;

namespace PRM392_Backend.Service.StoreLocations
{
	public interface IStoreLocationService
	{
		Task<StoreLocationForReturnDto> CreateStoreLocation(StoreLocationForCreationDto storeLocationForCreationDto);
		Task UpdateStoreLocation(Guid id, StoreLocationForUpdateDto storeLocationForUpdateDto, bool trackChange);
		Task<IEnumerable<StoreLocationForReturnDto>> GetAllStoreLocations(bool trackChange);
		Task<IEnumerable<StoreLocationForReturnDto>> GetActiveStoreLocations(bool trackChange);
		Task<StoreLocationForReturnDto?> GetStoreLocation(Guid id, bool trackChange);
	}
}
