using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Core.Services
{
	public interface IService<TEntity> where TEntity : class
	{
		Task<TEntity> GetById(int id);

		Task<IEnumerable<TEntity>> GetAll();

		Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

		TEntity Add(TEntity entity);

		Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);

		void Delete(int id);

		void DeleteRange(IEnumerable<TEntity> entities);

		TEntity Update(TEntity entity);
	}
}
