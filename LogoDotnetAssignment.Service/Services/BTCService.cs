using LogoDotnetAssignment.Core.Models;
using LogoDotnetAssignment.Core.Repositories;
using LogoDotnetAssignment.Core.Services;
using LogoDotnetAssignment.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Service.Services
{
	public class BTCService : Service<BTC>, IBTCService
	{
		public BTCService(IUnitOfWork unitOfWork, IReporsitory<BTC> repository) : base(unitOfWork, repository)
		{
		}

		public async Task<BTC> GetWithVirtualMoneyById(int btcId)
		{
			return await _unitOfWork.btc.GetWithVirtualMoneyById(btcId);
		}
	}
}
