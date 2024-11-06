using PRM392_Backend.Domain.PagedList;
using PRM392_Backend.Domain.Parameters;
using PRM392_Backend.Service.Products.DTO;

namespace PRM392_Backend.Service.Products
{
	public interface IProductService
	{
		Task<ProductForReturnDto> CreateProduct(ProductForCreationDto productForCreationDto);
		Task UpdateProduct(Guid id, ProductForUpdateDto productForUpdateDto, bool trackChange);
		Task<(IEnumerable<ProductForReturnDto> products, MetaData metaData)> GetAllProducts(ProductParameters productParameters, bool trackChange);
		Task<(IEnumerable<ProductForReturnDto> products, MetaData metaData)> GetActiveProducts(ProductParameters productParameters, bool trackChange);
		Task<ProductForReturnDto?> GetProduct(Guid id, bool trackChange);
    }
}
