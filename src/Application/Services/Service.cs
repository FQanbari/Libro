using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Application.Service;

public class Service<TEntity> : IService<TEntity> where TEntity : class
{
    private readonly IRepository<TEntity> _repository;
    public Service(IRepository<TEntity> repository)
    {
        _repository = repository;
    }
    public async Task AddOrUpdate(Object entity, CancellationToken cancellationToken)
    {
        await _repository.AddOrUpdate(entity as TEntity, cancellationToken);
    }

    public async Task<TEntity> FindById(CancellationToken cancellationToken, params object[] ids)
    {
        var result = await _repository.FindById(cancellationToken, ids);

        return result.Last();
    }

    public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await _repository.TableNoTracking.ToListAsync();
    }

    public async Task Remove(TEntity entity, CancellationToken cancellationToken)
    {
        await _repository.Remove(entity, cancellationToken);
    }
}
