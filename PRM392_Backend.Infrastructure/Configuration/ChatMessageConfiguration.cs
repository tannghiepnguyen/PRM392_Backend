using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
	{
		public void Configure(EntityTypeBuilder<ChatMessage> builder)
		{
			builder.HasKey(e => e.ID);
			builder.Property(e => e.Message).IsRequired();
			builder.Property(e => e.SentdAt).IsRequired();
			builder.Property(e => e.IsDeleted).IsRequired();
			builder.Property(e => e.DeletedAt).IsRequired(false);
			builder.HasOne(e => e.User).WithMany(e => e.ChatMessages).HasForeignKey(e => e.UserID).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
