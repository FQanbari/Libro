namespace Domain.Entities.BookAggregate;

public interface IRepository<T> where T : class
{
    Task<T> Get();
    Task AddOrUpdate(T model);
    Task Remove(T model);
}
