using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
	{
		public void Configure(EntityTypeBuilder<Payment> builder)
		{
			builder.HasKey(p => p.ID);
			builder.Property(p => p.Amount).IsRequired();
			builder.Property(p => p.PaymentDate).IsRequired();
			builder.Property(p => p.PaymentStatus).IsRequired();
			builder.HasOne(p => p.Order).WithOne(o => o.Payment).HasForeignKey<Payment>(p => p.OrderID);
		}
	}
}
