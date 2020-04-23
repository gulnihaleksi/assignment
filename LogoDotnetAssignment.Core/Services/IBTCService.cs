using LogoDotnetAssignment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Core.Services
{
	public interface IBTCService:IService<BTC>
	{
		Task<BTC> GetWithVirtualMoneyById(int btcId);
	}
}
