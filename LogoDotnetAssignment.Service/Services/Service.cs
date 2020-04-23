using LogoDotnetAssignment.Core.Repositories;
using LogoDotnetAssignment.Core.Services;
using LogoDotnetAssignment.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogoDotnetAssignment.Service.Services
{
	public class Service<TEntity> : IService<TEntity> where TEntity : class
	{
		public readonly IUnitOfWork _unitOfWork;
		private readonly IReporsitory<TEntity> _repository;

		public Service(IUnitOfWork unitOfWork , IReporsitory<TEntity> repository)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}

		public TEntity Add(TEntity entity)
		{
			 _repository.Add(entity);
			 _unitOfWork.Commit();
			  return entity;
		}

		public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
		{
			await _repository.AddRange(entities);
			await _unitOfWork.CommitAsync();
			return entities;
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
			//_unitOfWork.Commit();
		}

		public void DeleteRange(IEnumerable<TEntity> entities)
		{
			_repository.DeleteRange(entities);
			_unitOfWork.Commit();
		}

		public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return await _repository.Find(predicate);
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _repository.GetAll();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public TEntity Update(TEntity entity)
		{
			TEntity updateEntity = _repository.Update(entity);
			//_unitOfWork.Commit();
			return updateEntity;
		}
	}
}
