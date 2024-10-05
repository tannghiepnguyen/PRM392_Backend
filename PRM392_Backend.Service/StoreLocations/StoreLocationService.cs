using AutoMapper;
using PRM392_Backend.Domain.Exceptions;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.StoreLocations.DTO;

namespace PRM392_Backend.Service.StoreLocations
{
	internal sealed class StoreLocationService : IStoreLocationService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public StoreLocationService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}
		public async Task<StoreLocationForReturnDto> CreateStoreLocation(StoreLocationForCreationDto storeLocationForCreationDto)
		{
			var storeLocation = mapper.Map<StoreLocation>(storeLocationForCreationDto);
			storeLocation.ID = Guid.NewGuid();
			storeLocation.IsActive = true;

			repositoryManager.StoreLocationRepository.CreateStoreLocation(storeLocation);
			await repositoryManager.Save();

			return mapper.Map<StoreLocationForReturnDto>(storeLocation);
		}

		public async Task<IEnumerable<StoreLocationForReturnDto>> GetActiveStoreLocations(bool trackChange)
		{
			var activeStoreLocations = await repositoryManager.StoreLocationRepository.GetActiveStoreLocations(trackChange);
			return mapper.Map<IEnumerable<StoreLocationForReturnDto>>(activeStoreLocations);
		}

		public async Task<IEnumerable<StoreLocationForReturnDto>> GetAllStoreLocations(bool trackChange)
		{
			var storeLocations = await repositoryManager.StoreLocationRepository.GetStoreLocations(trackChange);
			return mapper.Map<IEnumerable<StoreLocationForReturnDto>>(storeLocations);
		}

		public async Task<StoreLocationForReturnDto?> GetStoreLocation(Guid id, bool trackChange)
		{
			var storeLocation = await repositoryManager.StoreLocationRepository.GetStoreLocationById(id, trackChange);
			if (storeLocation == null) throw new StoreLocationNotFoundException(id);

			return mapper.Map<StoreLocationForReturnDto>(storeLocation);
		}

		public async Task UpdateStoreLocation(Guid id, StoreLocationForUpdateDto storeLocationForUpdateDto, bool trackChange)
		{
			var storeLocation = await repositoryManager.StoreLocationRepository.GetStoreLocationById(id, trackChange);
			if (storeLocation == null) throw new StoreLocationNotFoundException(id);

			mapper.Map(storeLocationForUpdateDto, storeLocation);
			await repositoryManager.Save();
		}
	}
}
