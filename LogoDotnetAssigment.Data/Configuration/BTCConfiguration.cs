using LogoDotnetAssignment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogoDotnetAssignment.Data.Configuration
{
	public class BTCConfiguration : IEntityTypeConfiguration<BTC>
	{

		public void Configure(EntityTypeBuilder<BTC> builder)
		{
			builder.Property(x => x.price).IsRequired().HasColumnType("decimal(18,2)");
			builder.Property(x => x.volume_24h).HasColumnType("decimal(18,2)");
			builder.Property(x => x.percent_change_1h).HasColumnType("decimal(18,2)");
			builder.Property(x => x.percent_change_24h).HasColumnType("decimal(18,2)");
			builder.Property(x => x.percent_change_7d).HasColumnType("decimal(18,2)");
			builder.Property(x => x.market_cap).HasColumnType("decimal(18,2)");
			builder.ToTable("BTC");
		}
	}
}
