using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Service.Categories.DTO;
using PRM392_Backend.Service.IService;

namespace PRM392_Backend.API.Controllers
{
	[Route("api/categories")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public CategoriesController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await serviceManager.CategoryService.GetAllCategories(trackChange: false);
			return Ok(categories);
		}

		[HttpGet("active")]	
		public async Task<IActionResult> GetActiveCategories()
		{
			var categories = await serviceManager.CategoryService.GetActiveCategories(trackChange: false);
			return Ok(categories);
		}

		[HttpGet("{id:guid}")]		
		public async Task<IActionResult> GetCategory([FromRoute] Guid id)
		{
			var category = await serviceManager.CategoryService.GetCategory(id, trackChange: false);
			if (category == null) return NotFound();
			return Ok(category);
		}

		[HttpPost]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreationDto)
		{
			var category = await serviceManager.CategoryService.CreateCategory(categoryForCreationDto);
			return CreatedAtAction(nameof(GetCategory), new { id = category.ID }, category);
		}

		[HttpPut("{id:guid}")]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryForUpdateDto categoryForUpdateDto)
		{
			await serviceManager.CategoryService.UpdateCategory(id, categoryForUpdateDto, trackChange: false);
			return NoContent();
		}
	}
}
