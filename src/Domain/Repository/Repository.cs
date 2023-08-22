using Domain.Entities.BookAggregate;

namespace Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{

    public Task AddOrUpdate(T model)
    {
        throw new NotImplementedException();
    }

    public Task<T> Get()
    {
        throw new NotImplementedException();
    }

    public Task Remove(T model)
    {
        throw new NotImplementedException();
    }
}
