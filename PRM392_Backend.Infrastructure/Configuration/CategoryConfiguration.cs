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
			builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(1000);
			builder.Property(x => x.IsActive).IsRequired();

			builder.HasData(
				new Category
				{
					ID = Guid.Parse("5a2834d9-2630-4d1f-8126-daa29b800e78"),
					CategoryName = "Burgers",
					ImageUrl = "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fburger.jpg?alt=media&token=4913b4f4-b37f-44a6-9fae-48beec255483",

					IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("2d85ef10-9237-46e8-8131-955eb56c27f0"),
					CategoryName = "Pizzas",
					ImageUrl = "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fpizza.jpg?alt=media&token=ae5cf452-4184-4b20-9f39-c1a49ca5b975",

					IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("82de5b3d-ca35-420d-8e98-cc432b510201"),
					CategoryName = "Sushi",
					ImageUrl = "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fsushi.jpg?alt=media&token=c86cb412-e217-4f71-a64e-c6e17bc3d6c6",

					IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("804563c3-05f3-4997-98fd-b23e4a310fb6"),
					CategoryName = "Italian",
					ImageUrl = "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fmiy.jpg?alt=media&token=dc0800c8-8415-4c2b-90f1-8e26756dc469",

                    IsActive = true
				},
				new Category
				{
					ID = Guid.Parse("beffabc8-6f9f-4d08-b69a-8cb5226e8486"),
					CategoryName = "Chinese",
					ImageUrl = "https://firebasestorage.googleapis.com/v0/b/deliveroo-dab94.appspot.com/o/Splash%2Fchinese.jpg?alt=media&token=84155e4f-4949-4846-927a-5f0d7c08ed7b",
                    IsActive = true
				}
			);
        }
	}
}
