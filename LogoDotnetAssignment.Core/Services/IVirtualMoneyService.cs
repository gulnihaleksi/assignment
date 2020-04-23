using LogoDotnetAssignment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Core.Services
{
	public interface IVirtualMoneyService:IService<VirtualMoney>
	{
		Task<VirtualMoney> GetWithBTC(int virtualMoneyId);
	}
}
