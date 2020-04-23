using LogoDotnetAssignment.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace LogoDotnetAssignment.Data.Repositories
{
 public	class Repository<TEntity> : IReporsitory<TEntity> where TEntity : class
	{
		protected readonly DbContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public Repository(AppDbContext appDbContext)
		{
			_context = appDbContext;
			_dbSet = appDbContext.Set<TEntity>();
		}
		public void Add(TEntity entity)
		{

			using (var fs = new FileStream(@"Resources/assigment.json", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
			using (var sr = new StreamReader(fs, Encoding.Default))
			{
				string jsonData = sr.ReadToEnd();
				List<TEntity> items = JsonConvert.DeserializeObject<List<TEntity>>(jsonData);
				int maxId = items.Max(r => ((dynamic)r).id);
				((dynamic)entity).id = maxId + 1;
				fs.SetLength(fs.Length - 1);
				fs.Close();
				sr.Close();
			}
			string json = JsonConvert.SerializeObject(entity, Formatting.Indented);
			File.AppendAllText(@"Resources/assigment.json", "," + json + "]");
		}

		public async Task AddRange(IEnumerable<TEntity> entities)
		{
			await _dbSet.AddRangeAsync(entities);
		}

		public void Delete(int id)
		{
			using (var fs = new FileStream(@"Resources/assigment.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var sr = new StreamReader(fs, Encoding.Default))
			{
				string json = sr.ReadToEnd();
				List<TEntity> items = JsonConvert.DeserializeObject<List<TEntity>>(json);
				var deletedEntity = items.Find(r => ((dynamic)r).id == id);
				items.Remove(deletedEntity);
				string serJson = JsonConvert.SerializeObject(items, Formatting.Indented);
				File.WriteAllText(@"Resources/assigment.json", serJson);
				fs.Close();
				sr.Close();
			}
		}

		public void DeleteRange(IEnumerable<TEntity> entities)
		{
			_dbSet.RemoveRange(entities);
		}

		public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return await _dbSet.Where(predicate).ToListAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			using (var fs = new FileStream(@"Resources/assigment.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var sr = new StreamReader(fs, Encoding.Default))
			{
				string json = await sr.ReadToEndAsync();
				List<TEntity> items = JsonConvert.DeserializeObject<List<TEntity>>(json);
				sr.Close();
				return items;
			}
		}

		public async Task<TEntity> GetById(int id)
		{
			List<TEntity> items;
			using (var fs = new FileStream(@"Resources/assigment.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var sr = new StreamReader(fs, Encoding.Default))
			{
				string json = await sr.ReadToEndAsync();
				items = JsonConvert.DeserializeObject<List<TEntity>>(json);
				sr.Close();
			}
			var entity = items.Find(r => ((dynamic)r).id == id);
			return entity;
		}

		public TEntity Update(TEntity entity)
		{
			using (var fs = new FileStream(@"Resources/assigment.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var sr = new StreamReader(fs, Encoding.Default))
			{
				string json = sr.ReadToEnd();
				List<TEntity> items = JsonConvert.DeserializeObject<List<TEntity>>(json);
				var updatedEntity = items.Find(r => ((dynamic)r).id == ((dynamic)entity).id);
				((dynamic)updatedEntity).name = ((dynamic)entity).name;
				((dynamic)updatedEntity).slug = ((dynamic)entity).slug;
				((dynamic)updatedEntity).symbol = ((dynamic)entity).symbol;
				((dynamic)updatedEntity).num_market_pairs = ((dynamic)entity).num_market_pairs;
				string serJson = JsonConvert.SerializeObject(items, Formatting.Indented);
				File.WriteAllText(@"Resources/assigment.json", serJson);
				fs.Close();
				sr.Close();
				return entity;
			}
		}
	}
}
