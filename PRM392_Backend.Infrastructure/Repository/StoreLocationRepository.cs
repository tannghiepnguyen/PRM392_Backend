using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;

namespace PRM392_Backend.Infrastructure.Repository
{
	public class StoreLocationRepository : RepositoryBase<StoreLocation>, IStoreLocationRepository
	{
		public StoreLocationRepository(DatabaseContext context) : base(context)
		{
		}

		public void CreateStoreLocation(StoreLocation storeLocation) => Create(storeLocation);

		public async Task<IEnumerable<StoreLocation>> GetActiveStoreLocations(bool trackChange) => await FindByCondition(s => s.IsActive == true, trackChange).ToListAsync();

		public async Task<StoreLocation?> GetStoreLocationById(Guid id, bool trackChange) => await FindByCondition(s => s.ID == id, trackChange).FirstOrDefaultAsync();

		public async Task<IEnumerable<StoreLocation>> GetStoreLocations(bool trackChange) => await FindAll(trackChange).ToListAsync();
	}
}
