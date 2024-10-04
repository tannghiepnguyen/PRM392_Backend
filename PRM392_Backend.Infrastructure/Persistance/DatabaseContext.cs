using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRM392_Backend.Domain.Models;
using PRM392_Backend.Infrastructure.Configuration;

namespace PRM392_Backend.Infrastructure.Persistance
{
	public class DatabaseContext : IdentityDbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new CartConfiguration());
			modelBuilder.ApplyConfiguration(new CartItemConfiguration());
			modelBuilder.ApplyConfiguration(new PaymentConfiguration());
			modelBuilder.ApplyConfiguration(new NotificationConfiguration());
			modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
			modelBuilder.ApplyConfiguration(new StoreLocationConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<ChatMessage> ChatMessages { get; set; }
		public DbSet<StoreLocation> StoreLocations { get; set; }

	}
}
