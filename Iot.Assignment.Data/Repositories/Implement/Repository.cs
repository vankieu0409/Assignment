using System.Collections.ObjectModel;
using System.Reflection;
using Iot.Assignment.Data.Repositories.Interface;
using Iot.Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Iot.Assignment.Data.Repositories.Implement;

public class Repository<TEntity>:IRepository<TEntity> where TEntity : class
{

    private readonly DbContext _dbContext;
    public DbSet<TEntity> Entities { get; set; }

    public Repository(DbContext dbContext)
    {
        this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.Entities = this._dbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        return (await this.Entities.AddAsync(entity, cancellationToken)).Entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
        Collection<TEntity> resullt = new Collection<TEntity>();
        foreach (var entity in entities)
        {
            Collection<TEntity> collection = resullt;
            collection.Add(await this.AddAsync(entity, cancellationToken));
            collection = (Collection<TEntity>)null;
        }

        IEnumerable<TEntity> entityColletion = (IEnumerable<TEntity>)resullt;
        return entityColletion;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        this.Entities.Attach(entity);
        return await Task.FromResult<TEntity>(this.Entities.Update(entity).Entity);
    }

    public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
        Collection<TEntity> result = new Collection<TEntity>();
        foreach (TEntity entity in entities)
        {
            Collection<TEntity> collection = result;
            collection.Add(await this.UpdateAsync(entity, cancellationToken));
            collection = (Collection<TEntity>)null;
        }
        IEnumerable<TEntity> entityCollection = (IEnumerable<TEntity>)result;
        result = (Collection<TEntity>)null;
        return entityCollection;
    }

    public async Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        if (this.IsInheritsFrom((object)entity, typeof(FullEntityBase<TEntity>)))
        {
            PropertyInfo property = entity.GetType().GetProperty("IsDeleted");
            property.SetValue((object)entity, Convert.ChangeType((object)true, property.PropertyType), (object[])null);
            return await this.UpdateAsync(entity, cancellationToken);
        }
        this.Entities.Attach(entity);
        return await Task.FromResult<TEntity>(this.Entities.Remove(entity).Entity);
    }

    public async Task<IEnumerable<TEntity>> RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
        Collection<TEntity> result = new Collection<TEntity>();
        foreach (TEntity entity in entities)
        {
            Collection<TEntity> collection = result;
            collection.Add(await this.RemoveAsync(entity, cancellationToken));
            collection = (Collection<TEntity>)null;
        }

        IEnumerable<TEntity> entityCollection = (IEnumerable<TEntity>)result;
        result = (Collection<TEntity>)null;
        return entityCollection;
    }

    public IQueryable<TEntity> AsQueryable() => (IQueryable<TEntity>)this._dbContext.Set<TEntity>().AsNoTracking();


    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) => await this._dbContext.SaveChangesAsync(cancellationToken);

    private bool IsInheritsFrom(object source, Type baseType)
    {
        Type type1 = source.GetType();
        if (type1 == (Type)null)
            return false;
        if (baseType == (Type)null)
            return type1.IsInterface || type1 == typeof(object);
        if (baseType.IsInterface)
            return ((IEnumerable<Type>)type1.GetInterfaces()).Contains<Type>(baseType);
        Type type2 = type1;
        if (!(type2 != (Type)null))
            return false;
        if (type2.BaseType == baseType)
            return true;
        Type baseType1 = type2.BaseType;
        return this.IsInheritsFrom(source, baseType1);
    }

}