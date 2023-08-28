using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;
namespace Domain.Entities;

public interface IRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> Entities { get; }
    //IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }
    Task<List<TEntity>> FindById(CancellationToken cancellationToken, params object[] ids);
    Task AddOrUpdate(TEntity entity, CancellationToken cancellationToken);
    Task Remove(TEntity entity, CancellationToken cancellationToken);
}
