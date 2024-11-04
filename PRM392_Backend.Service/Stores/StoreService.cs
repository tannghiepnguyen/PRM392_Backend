using AutoMapper;
using Microsoft.AspNetCore.Http;
using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Service.Notifications.DTO;
using PRM392_Backend.Service.Stores.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.Stores
{
    public class StoreService : IStoreService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public StoreService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StoreResponse>> GetAllStores(bool trackChange)
        {           
            var stores = await repositoryManager.StoreRepository.GetStores(trackChange);
            return mapper.Map<IEnumerable<StoreResponse>>(stores);
        }

        public async Task<GetProductByStoreIdResponse> GetProductsByStoreId(Guid id, bool trackChange)
        {
            var store = await repositoryManager.StoreRepository.GetProductsByStoreId(id, trackChange);
            return mapper.Map<GetProductByStoreIdResponse>(store);
        }
    }
}
