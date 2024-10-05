using PRM392_Backend.Service.Carts;
using PRM392_Backend.Service.Categories;
using PRM392_Backend.Service.Products;
using PRM392_Backend.Service.StoreLocations;
using PRM392_Backend.Service.Users;

namespace PRM392_Backend.Service.IService
{
	public interface IServiceManager
	{
		IAuthenticationService AuthenticationService { get; }
		ICategoryService CategoryService { get; }
		IStoreLocationService StoreLocationService { get; }
		IProductService ProductService { get; }
		ICartService CartService { get; }
	}
}
