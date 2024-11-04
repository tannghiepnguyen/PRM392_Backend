using PRM392_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Domain.Repository
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetStores(bool trackChange);
        Task<Store?> GetProductsByStoreId(Guid id, bool trackChange); 
    }
}
