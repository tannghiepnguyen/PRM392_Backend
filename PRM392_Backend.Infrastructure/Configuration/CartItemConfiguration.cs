using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
	{
		public void Configure(EntityTypeBuilder<CartItem> builder)
		{
			builder.HasKey(e => e.ID);
			builder.Property(e => e.Quantity).IsRequired();
			builder.Property(e => e.Price).IsRequired();
			builder.HasOne(e => e.Cart)
				.WithMany(e => e.CartItems)
				.HasForeignKey(e => e.CartID)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(e => e.Product).WithMany(e => e.CartItem).HasForeignKey(e => e.ProductID).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
