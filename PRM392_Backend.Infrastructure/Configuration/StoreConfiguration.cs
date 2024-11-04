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
			//builder.HasMany(e => e.Products).WithOne(e => e.Store).OnDelete(DeleteBehavior.Restrict);
            builder.Property(e => e.Address).IsRequired();
			builder.Property(e => e.IsActive).IsRequired();
		}
	}
}
