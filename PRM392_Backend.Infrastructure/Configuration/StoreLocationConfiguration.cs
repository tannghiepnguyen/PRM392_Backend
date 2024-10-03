using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class StoreLocationConfiguration : IEntityTypeConfiguration<StoreLocation>
	{
		public void Configure(EntityTypeBuilder<StoreLocation> builder)
		{
			builder.HasKey(e => e.ID);
			builder.Property(e => e.Address).IsRequired();
			builder.Property(e => e.Latitude).IsRequired();
			builder.Property(e => e.Longitude).IsRequired();
			builder.HasMany(e => e.Orders).WithOne(e => e.StoreLocation).HasForeignKey(e => e.StoreLocationID);
		}
	}
}
