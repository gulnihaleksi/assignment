using LogoDotnetAssignment.Core.Models;
using LogoDotnetAssignment.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Data.Repositories
{
	public class BTCRepository : Repository<BTC>, IBTCRepository
	{
		private AppDbContext _appDbContext { get => _context as AppDbContext; }
		public BTCRepository(AppDbContext context) : base(context)
		{

		}

		public async Task<BTC> GetWithVirtualMoneyById(int btcId)
		{
			return await _appDbContext.BTCs.SingleOrDefaultAsync(x => x.id == btcId);
		}
	}
}
