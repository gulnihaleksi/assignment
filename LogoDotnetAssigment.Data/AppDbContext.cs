using LogoDotnetAssignment.Core.Models;
using LogoDotnetAssignment.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LogoDotnetAssignment.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base
			(options)
		{

		}

		public DbSet<VirtualMoney> VirtualMoneys { get; set; }
		public DbSet<BTC> BTCs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new VirtualMoneyConfiguration());
			modelBuilder.ApplyConfiguration(new BTCConfiguration());
		}
	}
}
