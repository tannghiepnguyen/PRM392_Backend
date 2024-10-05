using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
	{
		public void Configure(EntityTypeBuilder<Notification> builder)
		{
			builder.HasKey(e => e.ID);
			builder.Property(e => e.Message).IsRequired();
			builder.Property(e => e.IsRead).IsRequired();
			builder.Property(e => e.CreatedAt).IsRequired();
			builder.Property(e => e.IsActive).IsRequired();
			builder.HasOne(e => e.Users).WithMany(e => e.Notifications).HasForeignKey(e => e.UserID).OnDelete(DeleteBehavior.Restrict);

		}
	}
}
