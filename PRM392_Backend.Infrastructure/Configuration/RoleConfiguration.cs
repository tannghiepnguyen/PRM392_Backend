using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole
				{
					Id = "3cb28e4f-3fd1-434b-9935-779228be461d",
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole
				{
					Id = "fca9741b-e4c7-4597-9a82-0f2f9621e747",
					Name = "Customer",
					NormalizedName = "CUSTOMER"
				}
			);
		}
	}
}
