using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary Key
            builder.HasKey(o => o.ID);

            // Properties
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.BillingAddress).IsRequired();
            builder.Property(o => o.PaymentMethod)
                   .IsRequired()
                   .HasConversion<string>(); 
            builder.Property(o => o.OrderStatus)
                   .IsRequired()
                   .HasConversion<string>(); 

            // Relationships
            builder.HasOne(o => o.Cart)
                   .WithOne(c => c.Order)
                   .HasForeignKey<Order>(o => o.CartID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.StoreLocation)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(o => o.StoreLocationID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
