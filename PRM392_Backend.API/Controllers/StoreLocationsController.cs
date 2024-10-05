using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.StoreLocations.DTO;

namespace PRM392_Backend.API.Controllers
{
	[Route("api/store-locations")]
	[ApiController]
	public class StoreLocationsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public StoreLocationsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetStoreLocations()
		{
			var storeLocations = await serviceManager.StoreLocationService.GetAllStoreLocations(trackChange: false);
			return Ok(storeLocations);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActiveStoreLocations()
		{
			var activeStoreLocations = await serviceManager.StoreLocationService.GetActiveStoreLocations(trackChange: false);
			return Ok(activeStoreLocations);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetStoreLocation([FromRoute] Guid id)
		{
			var storeLocation = await serviceManager.StoreLocationService.GetStoreLocation(id, trackChange: false);
			if (storeLocation == null)
			{
				return NotFound();
			}
			return Ok(storeLocation);
		}

		[HttpPost]
		public async Task<IActionResult> CreateStoreLocation([FromBody] StoreLocationForCreationDto storeLocationForCreationDto)
		{
			var storeLocation = await serviceManager.StoreLocationService.CreateStoreLocation(storeLocationForCreationDto);
			return CreatedAtAction(nameof(GetStoreLocation), new { id = storeLocation.ID }, storeLocation);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateStoreLocation([FromRoute] Guid id, [FromBody] StoreLocationForUpdateDto storeLocationForUpdateDto)
		{
			await serviceManager.StoreLocationService.UpdateStoreLocation(id, storeLocationForUpdateDto, trackChange: false);
			return NoContent();
		}
	}
}
