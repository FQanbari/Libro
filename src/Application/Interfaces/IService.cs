namespace Application.Interfaces;

public interface IService<TEntity> where TEntity : class
{
    Task<TEntity> FindById(CancellationToken cancellationToken, params object[] ids);
    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);
    Task AddOrUpdate(object entity, CancellationToken cancellationToken);
    Task Remove(TEntity entity, CancellationToken cancellationToken);
}
