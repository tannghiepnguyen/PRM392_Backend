using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Infrastructure.Repository
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Store>> GetStores(bool trackChange) => await FindAll(trackChange)
             .OrderByDescending(s => s.Rating)
             .ToListAsync();

        public async Task<Store?> GetProductsByStoreId(Guid id, bool trackChange)
            => await FindByCondition(x => x.ID == id, trackChange)
            .Include(x => x.Products)
            .ThenInclude(p => p.Category)
            .SingleOrDefaultAsync();
    }
}
