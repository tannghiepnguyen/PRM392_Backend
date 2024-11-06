using PRM392_Backend.Domain.PagedList;
using PRM392_Backend.Domain.Parameters;
using PRM392_Backend.Service.Products.DTO;
using PRM392_Backend.Service.Stores.DTO;

namespace PRM392_Backend.Service.Products
{
	public interface IProductService
	{
		Task<ProductForReturnDto> CreateProduct(ProductForCreationDto productForCreationDto);
		Task UpdateProduct(Guid id, ProductForUpdateDto productForUpdateDto, bool trackChange);
		Task<(IEnumerable<ProductForReturnDto> products, MetaData metaData)> GetProducts(ProductParameters productParameters, bool trackChange);
		Task<IEnumerable<ProductForReturnDto>> GetAllProducts(bool trackChange);

        Task<(IEnumerable<ProductForReturnDto> products, MetaData metaData)> GetActiveProducts(ProductParameters productParameters, bool trackChange);
		Task<ProductForReturnDto?> GetProduct(Guid id, bool trackChange);
    }
}
