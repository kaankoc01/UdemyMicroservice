using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyMicroservice.Order.Application.Contracts.Repositories;
using UdemyMicroservice.Order.Domain.Entity;

namespace UdemyMicroservice.Order.Persistence.Repositories
{
	public class GenericRepository<TId, TEntity>(AppDbContext context) : IGenericRepository<TId, TEntity> where TId : struct where TEntity : BaseEntity<TId>
	{
		protected AppDbContext Context = context;
		private readonly DbSet<TEntity> _dbset = context.Set<TEntity>();
		
		public Task<bool> AnyAsync(TId id)
		{
			return _dbset.AnyAsync(x => x.Id.Equals(id));
		}

		public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbset.AnyAsync(predicate);
		}

		public void Remove(TEntity entity)
		{
			_dbset.Remove(entity);
		}
		public Task<List<TEntity>> GetAllAsync()
		{
			return _dbset.ToListAsync();
		}

		public Task<List<TEntity>> GetAllPagedAsync(int pageNumber, int pageSize)
		{
			return _dbset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public ValueTask<TEntity?> GetByIdAsync(TId id)
		{
			return _dbset.FindAsync(id);
		}

		public void Add(TEntity entity)
		{
			_dbset.Add(entity);
		}

		public void Update(TEntity entity)
		{
			_dbset.Update(entity);
		}

		public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbset.Where(predicate);
		}
	}
}
