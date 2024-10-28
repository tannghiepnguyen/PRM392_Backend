using PRM392_Backend.Domain.Repository;
using PRM392_Backend.Infrastructure.Persistance;
using System;

namespace PRM392_Backend.Infrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DatabaseContext context;
        private readonly Lazy<ICategoryRepository> categoryRepository;
        private readonly Lazy<IStoreLocationRepository> storeLocationRepository;
        private readonly Lazy<IProductRepository> productRepository;
        private readonly Lazy<ICartRepository> cartRepository;
        private readonly Lazy<ICartItemRepository> itemRepository;
        private readonly Lazy<IOrderRepository> orderRepository;
        private readonly Lazy<IChatMessageRepository> chatMessageRepository;
        private readonly Lazy<IPaymentRepository> paymentRepository;
        private readonly Lazy<INotificationRepository> notificationRepository;

        public RepositoryManager(DatabaseContext databaseContext)
        {
            context = databaseContext;
            categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            storeLocationRepository = new Lazy<IStoreLocationRepository>(() => new StoreLocationRepository(context));
            productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
            cartRepository = new Lazy<ICartRepository>(() => new CartRepository(context));
            itemRepository = new Lazy<ICartItemRepository>(() => new CartItemRepository(context));
            orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(context));
            chatMessageRepository = new Lazy<IChatMessageRepository>(() => new ChatMessageRepository(context));
            paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(context));
            notificationRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(context));
        }

        public ICategoryRepository CategoryRepository => categoryRepository.Value;

        public IStoreLocationRepository StoreLocationRepository => storeLocationRepository.Value;

        public IProductRepository ProductRepository => productRepository.Value;
        public ICartRepository CartRepository => cartRepository.Value;
        public ICartItemRepository CartItemRepository => itemRepository.Value;
        public IOrderRepository OrderRepository => orderRepository.Value;
        public IChatMessageRepository ChatMessageRepository => chatMessageRepository.Value;
        public IPaymentRepository PaymentRepository => paymentRepository.Value;
        public INotificationRepository NotificationRepository => notificationRepository.Value;

        public async Task Save() => await context.SaveChangesAsync();
    }
}
