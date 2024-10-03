using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.ID);
			builder.Property(p => p.ProductName).HasMaxLength(100).IsRequired();
			builder.Property(p => p.BriefDescription).HasMaxLength(255).IsRequired();
			builder.Property(p => p.FullDescription).IsRequired();
			builder.Property(p => p.TechnicalSpecification).IsRequired();
			builder.Property(p => p.ImageURL).IsRequired();
			builder.Property(p => p.Price).IsRequired();
			builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(p => p.CartItem).WithOne(ci => ci.Product).OnDelete(DeleteBehavior.Restrict);
			builder.Property(p => p.IsDeleted).IsRequired();
			builder.Property(p => p.DeletedAt).IsRequired();
		}
	}
}
