using LogoDotnetAssignment.Core.Models;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Core.Repositories
{
	public interface IBTCRepository:IReporsitory<BTC>
	{
		Task<BTC> GetWithVirtualMoneyById(int btcId);
	}
}
