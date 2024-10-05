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
			builder.Property(x => x.IsActive).IsRequired();

			builder.HasData(
				new Category
				{
					ID = Guid.Parse("5a2834d9-2630-4d1f-8126-daa29b800e78"),
					CategoryName = "Burgers",
					IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("2d85ef10-9237-46e8-8131-955eb56c27f0"),
					CategoryName = "Pizzas",
					IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("82de5b3d-ca35-420d-8e98-cc432b510201"),
					CategoryName = "Drinks",
					IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("804563c3-05f3-4997-98fd-b23e4a310fb6"),
					CategoryName = "Desserts",
					IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("beffabc8-6f9f-4d08-b69a-8cb5226e8486"),
					CategoryName = "Chickens",
					IsActive = true
				}
			);
		}
	}
}
