using LogoDotnetAssignment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogoDotnetAssignment.Data.Seeds
{
	public class VirtualMoneySeed:IEntityTypeConfiguration<VirtualMoney>
	{
		private readonly int[] _ids;
		public VirtualMoneySeed(int[] ids)
		{
		_ids = ids;
		}

		public void Configure(EntityTypeBuilder<VirtualMoney> builder)
		{
			
		}
	}
}
