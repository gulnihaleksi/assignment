using LogoDotnetAssignment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogoDotnetAssignment.Data.Configuration
{
	class VirtualMoneyConfiguration : IEntityTypeConfiguration<VirtualMoney>
	{
		public void Configure(EntityTypeBuilder<VirtualMoney> builder)
		{
			builder.HasKey(x => x.id);
			builder.Property(x => x.id).UseSqlServerIdentityColumn();
			builder.Property(x => x.name).IsRequired().HasMaxLength(200);
			builder.Property(x => x.cmc_rank).IsRequired().HasColumnType("int");
			builder.Property(x => x.num_market_pairs).IsRequired().HasColumnType("int");
			builder.Property(x => x.max_supply).IsRequired().HasColumnType("int");
			builder.Property(x => x.circulating_supply).IsRequired().HasColumnType("int");
			builder.Property(x => x.total_supply).IsRequired().HasColumnType("int");
			builder.Property(x => x.slug).HasMaxLength(250);
			builder.Property(x => x.symbol).HasMaxLength(250);
			builder.ToTable("VirtualMoney");
		}
	}
}
