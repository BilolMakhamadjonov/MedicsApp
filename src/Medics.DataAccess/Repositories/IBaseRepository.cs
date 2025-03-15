using Medics.Core.Comman;
using System.Linq.Expressions;

namespace Medics.DataAccess.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}
