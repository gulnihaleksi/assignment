using LogoDotnetAssignment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Core.Repositories
{
	public interface IVirtualMoneyRepository:IReporsitory<VirtualMoney>
	{
		Task<VirtualMoney> GetWithBTC(int virtualMoneyId);
	}
}
