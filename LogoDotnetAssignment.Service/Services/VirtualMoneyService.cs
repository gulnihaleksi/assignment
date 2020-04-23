using LogoDotnetAssignment.Core.Models;
using LogoDotnetAssignment.Core.Repositories;
using LogoDotnetAssignment.Core.Services;
using LogoDotnetAssignment.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Service.Services
{
	public class VirtualMoneyService : Service<VirtualMoney>, IVirtualMoneyService
	{
		public VirtualMoneyService(IUnitOfWork unitOfWork, IReporsitory<VirtualMoney> repository) : base(unitOfWork, repository)
		{
		}

		public async Task<VirtualMoney> GetWithBTC(int virtualMoneyId)
		{
			return await _unitOfWork.virtualMoney.GetWithBTC(virtualMoneyId);
		}
	}
}
