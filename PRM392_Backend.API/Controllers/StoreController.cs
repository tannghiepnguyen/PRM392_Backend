using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Service.IService;

namespace PRM392_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public StoreController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var stores = await serviceManager.StoreService.GetAllStores(trackChange: false);
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByStoreId([FromRoute] Guid id)
        {
            var store = await serviceManager.StoreService.GetProductsByStoreId(id, trackChange: false);
            if (store == null) return NotFound();
            return Ok(store);
        }
    }
}
