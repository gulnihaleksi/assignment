using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Core.Repositories
{
	public interface IReporsitory<TEntity> where TEntity: class
	{
		Task<TEntity> GetById(int id);

		Task<IEnumerable<TEntity>> GetAll();

		Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity,bool>> predicate);

		void Add(TEntity entity);

		Task AddRange(IEnumerable<TEntity> entities);

		void Delete(int id);

		void DeleteRange(IEnumerable<TEntity> entities);

		TEntity Update(TEntity entity);

	}
}
