using LogoDotnetAssignment.Core.Models;
using LogoDotnetAssignment.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Data.Repositories
{
	public class VirtualMoneyRepository : Repository<VirtualMoney>, IVirtualMoneyRepository
	{
		private AppDbContext _appDbContext { get => _context as AppDbContext; }
		public VirtualMoneyRepository(AppDbContext context) : base(context)
		{

		}

		public async Task<VirtualMoney> GetWithBTC(int virtualMoneyId)
		{
			return await _appDbContext.VirtualMoneys.Include(x => x.qoute).SingleOrDefaultAsync(x => x.id == virtualMoneyId);
		}
	}
}
