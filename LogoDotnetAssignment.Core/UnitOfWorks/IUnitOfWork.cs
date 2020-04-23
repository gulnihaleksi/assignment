using LogoDotnetAssignment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Core.UnitOfWorks
{
	public interface IUnitOfWork
	{
		IVirtualMoneyRepository virtualMoney { get; }

		IBTCRepository btc { get; }
		Task CommitAsync();
		void Commit();
	}
}
