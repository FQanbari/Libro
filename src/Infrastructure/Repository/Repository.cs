using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Models.Base;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;
    public DbSet<TEntity> Entities { get; }
    public IQueryable<TEntity> Table => Entities;
    public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    public Repository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
        Entities = _dbContext.Set<TEntity>();
    }
    public async Task AddOrUpdate(TEntity entity, CancellationToken cancellationToken)
    {
        Assert.NotNull(entity, nameof(entity));
        await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Remove(TEntity entity, CancellationToken cancellationToken)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<TEntity>> FindById(CancellationToken cancellationToken, params object[] ids)
    {
        var result = await Entities.FindAsync(ids, cancellationToken).ConfigureAwait(false);

        return new List<TEntity> { result };
    }
}
