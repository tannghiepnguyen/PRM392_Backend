using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class CartConfiguration : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.HasKey(c => c.ID);
			builder.Property(c => c.TotalPrice).IsRequired();
			builder.Property(c => c.Status).IsRequired();
			builder.Property(c => c.IsActive).IsRequired();
			builder.HasOne(c => c.User).WithMany(u => u.Carts).HasForeignKey(c => c.UserID).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(c => c.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartID).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
