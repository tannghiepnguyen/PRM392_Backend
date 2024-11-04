using PRM392_Backend.Service.Notifications.DTO;
using PRM392_Backend.Service.Stores.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Stores
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreResponse>> GetAllStores(bool trackChange);
        Task<GetProductByStoreIdResponse> GetProductsByStoreId(Guid id, bool trackChange);
    }
}
