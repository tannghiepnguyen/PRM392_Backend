﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(e => e.Address).HasMaxLength(255).IsRequired();
			builder.Property(e => e.IsActive).IsRequired();
			builder.Property(e => e.FullName).HasMaxLength(255).IsRequired();
			builder.Property(e => e.RefreshToken).IsRequired();
			builder.Property(e => e.RefreshTokenExpiryTime).IsRequired();

		}
	}
}
