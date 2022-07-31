using Microsoft.EntityFrameworkCore;

namespace Iot.Assignment.Data.Repositories.Interface;

public interface IRepository<TEntity> where TEntity : class
{

    DbSet<TEntity> Entities { get; set; }

    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    Task<IEnumerable<TEntity>> RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

    IQueryable<TEntity> AsQueryable();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

}