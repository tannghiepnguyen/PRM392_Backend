namespace PRM392_Backend.Domain.Repository
{
	public interface IRepositoryManager
	{
		ICategoryRepository CategoryRepository { get; }
		IStoreLocationRepository StoreLocationRepository { get; }
		IProductRepository ProductRepository { get; }
		ICartRepository CartRepository { get; }
		ICartItemRepository CartItemRepository { get; }
		IOrderRepository OrderRepository { get; }
		IChatMessageRepository ChatMessageRepository { get; }
		IPaymentRepository PaymentRepository { get; }
		INotificationRepository NotificationRepository { get; }
		Task Save();
	}
}
