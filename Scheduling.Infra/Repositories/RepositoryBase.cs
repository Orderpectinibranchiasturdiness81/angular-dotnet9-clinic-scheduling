using Common;
using Microsoft.EntityFrameworkCore;
using Scheduling.Infra.Context;
using Scheduling.Domain.IRepositories;
using System.Linq.Expressions;
using Scheduling.Domain.Models;
using Scheduling.Domain.Enum;

namespace Scheduling.Infra.Repositories
{
    public class RepositoryBase<T> :  IRepository<T> where T : DomainEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        //-------------------------------------------------------------**
        #region Query Methods

        public virtual IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T?> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<List<T>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> ListAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<PagedDataDto<T>> PageAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize, OrderDirection orderDirection = OrderDirection.OrderBy)
        {
            var pagedData = new PagedDataDto<T>();

            var query = _dbSet.Where(predicate);

            //// Apply ordering if needed
            //if (orderDirection == OrderDirection.OrderBy)
            //{
            //    query = query.OrderBy(x => x); // Modify the order by condition as needed
            //}
            //else
            //{
            //    query = query.OrderByDescending(x => x); // Modify the order by condition as needed
            //}

            var pagedQuery = query.Skip(pageIndex * pageSize).Take(pageSize);

            pagedData.TotalCount = await query.CountAsync();
            pagedData.Data = await pagedQuery.ToListAsync();

            return pagedData;
        }


        public virtual async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        #endregion

        #region CRUD Methods

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }

}
