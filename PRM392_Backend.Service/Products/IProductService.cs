using PRM392_Backend.Service.Products.DTO;

namespace PRM392_Backend.Service.Products
{
	public interface IProductService
	{
		Task<ProductForReturnDto> CreateProduct(ProductForCreationDto productForCreationDto);
		Task UpdateProduct(Guid id, ProductForUpdateDto productForUpdateDto, bool trackChange);
		Task<IEnumerable<ProductForReturnDto>> GetAllProducts(bool trackChange);
		Task<IEnumerable<ProductForReturnDto>> GetActiveProducts(bool trackChange);
		Task<ProductForReturnDto?> GetProduct(Guid id, bool trackChange);
		Task<IEnumerable<ProductForReturnDto>> GetProductsByCategory(Guid categoryId, bool trackChange);
	}
}
