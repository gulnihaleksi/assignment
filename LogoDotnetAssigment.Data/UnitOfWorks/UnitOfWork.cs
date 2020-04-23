using LogoDotnetAssignment.Core.Repositories;
using LogoDotnetAssignment.Core.UnitOfWorks;
using LogoDotnetAssignment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Data.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		private VirtualMoneyRepository _virtualMoneyRepository;
		private BTCRepository _btcRepository;

		public UnitOfWork(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}

		public IVirtualMoneyRepository virtualMoney => _virtualMoneyRepository = _virtualMoneyRepository ?? new VirtualMoneyRepository(_context);

		public IBTCRepository btc => _btcRepository = _btcRepository ?? new BTCRepository(_context);

		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
