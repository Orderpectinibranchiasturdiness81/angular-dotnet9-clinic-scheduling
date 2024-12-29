using Common;
using Scheduling.Domain.Enum;
using Scheduling.Domain.Models;
using System.Linq.Expressions;

namespace Scheduling.Domain.IRepositories
{
    public interface IRepository<T> where T : DomainEntity
    {
        IQueryable<T> Query();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAllAsync(Expression<Func<T, bool>> predicate);
        Task<PagedDataDto<T>> PageAsync(
            Expression<Func<T, bool>> predicate,
            int pageIndex,
            int pageSize,
            OrderDirection orderDirection = OrderDirection.OrderBy);

        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
