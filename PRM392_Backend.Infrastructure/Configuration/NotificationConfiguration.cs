using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
	{
		public void Configure(EntityTypeBuilder<Notification> builder)
		{
			builder.HasKey(e => e.NotificationID);
			builder.Property(e => e.Message).IsRequired();
			builder.Property(e => e.IsRead).IsRequired();
			builder.Property(e => e.CreatedAt).IsRequired();
			builder.Property(e => e.UserID).IsRequired();
		}
	}
}
