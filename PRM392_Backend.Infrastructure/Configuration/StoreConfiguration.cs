using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class StoreConfiguration : IEntityTypeConfiguration<Store>
	{
		public void Configure(EntityTypeBuilder<Store> builder)
		{
			builder.HasKey(e => e.ID);
			builder.Property(e => e.StoreName).IsRequired().HasMaxLength(100);
			builder.HasMany(e => e.Products).WithOne(e => e.Store).OnDelete(DeleteBehavior.Restrict);
			builder.Property(e => e.Address).IsRequired();
			builder.Property(e => e.IsActive).IsRequired();
			builder.HasData(
                new Store
                {
                    ID = Guid.Parse("deb70b97-b1fc-48f6-860c-fe9c15bcc4c7"),
                    StoreName = "Burger Haven",
                    Address = "123 Main St, District 1, Ho Chi Minh City",
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("275dd30a-7b06-465a-9731-e0b75f2b4441"),
                    StoreName = "Pizza Paradise",
                    Address = "45 Sakura Ave, District 2, Ho Chi Minh City",
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("0edc6c88-6d86-42e7-9e1c-ff5821f8e366"),
                    StoreName = "Cool Refreshments",
                    Address = "78 Elm St, District 3, Ho Chi Minh City",
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("b1658d47-bc38-4690-9035-85c2e2d85d7c"),
                    StoreName = "Sweet Indulgence",
                    Address = "12 Greenway Dr, District 5, Ho Chi Minh City",
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("036975aa-0bae-455a-a559-d0c914a43b27"),
                    StoreName = "Crispy Corner",
                    Address = "99 Fiesta Ln, District 7, Ho Chi Minh City",
                    IsActive = true
                }              
            );

        }
	}
}
