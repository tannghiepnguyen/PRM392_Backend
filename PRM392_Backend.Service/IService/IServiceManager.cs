using PRM392_Backend.Service.CartItems;
using PRM392_Backend.Service.Carts;
using PRM392_Backend.Service.Categories;
using PRM392_Backend.Service.ChatMessages;
using PRM392_Backend.Service.Orders;
using PRM392_Backend.Service.Payments;
using PRM392_Backend.Service.Products;
using PRM392_Backend.Service.StoreLocations;
using PRM392_Backend.Service.Users;
using PRM392_Backend.Service.Notifications;

namespace PRM392_Backend.Service.IService
{
	public interface IServiceManager
	{
		IAuthenticationService AuthenticationService { get; }
		ICategoryService CategoryService { get; }
		IStoreLocationService StoreLocationService { get; }
		IProductService ProductService { get; }
		ICartService CartService { get; }
		ICartItemService CartItemService { get; }
		IOrderService OrderService { get; }
		IChatMessageService ChatMessageService { get; }
        IPaymentService PaymentService { get; }
        INotificationService NotificationService { get; }

    }
}
