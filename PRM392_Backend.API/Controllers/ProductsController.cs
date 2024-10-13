using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRM392_Backend.Domain.Constant;
using PRM392_Backend.Service.IService;
using PRM392_Backend.Service.Products.DTO;

namespace PRM392_Backend.API.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public ProductsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		[Authorize(Roles = Roles.Customer)]
		public async Task<IActionResult> GetProducts()
		{
			var products = await serviceManager.ProductService.GetAllProducts(trackChange: false);
			return Ok(products);
		}

		[HttpGet("{id:guid}")]
		[Authorize(Roles = Roles.Customer)]
		public async Task<IActionResult> GetProduct([FromRoute] Guid id)
		{
			var product = await serviceManager.ProductService.GetProduct(id, trackChange: false);
			return Ok(product);
		}

		[HttpPost]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> CreateProduct([FromForm] ProductForCreationDto productForCreationDto)
		{
			var product = await serviceManager.ProductService.CreateProduct(productForCreationDto);
			return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
		}

		[HttpGet("active")]
		[Authorize(Roles = Roles.Customer)]
		public async Task<IActionResult> GetActiveProducts()
		{
			var products = await serviceManager.ProductService.GetActiveProducts(trackChange: false);
			return Ok(products);
		}

		[HttpPut("{id:guid}")]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromForm] ProductForUpdateDto productForUpdateDto)
		{
			await serviceManager.ProductService.UpdateProduct(id, productForUpdateDto, trackChange: true);
			return NoContent();
		}
	}
}
