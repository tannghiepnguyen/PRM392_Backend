using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
			builder.HasMany(x => x.Products).WithOne(x => x.Category).OnDelete(DeleteBehavior.Restrict);
			builder.Property(x => x.IsDeleted).IsRequired();
			builder.Property(x => x.DeletedAt).IsRequired();
		}
	}
}
