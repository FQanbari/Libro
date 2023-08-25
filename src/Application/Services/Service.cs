using Application.Interface;
using Infrastructure.Repository;

namespace Application.Service;

public class Service<T> : IService<T> where T : class
{
    private readonly Repository<T> _repository;
    public Service(Repository<T> repository)
    {
        _repository = repository;
    }
    public async Task AddOrUpdate(T model)
    {
        await _repository.AddOrUpdate(model);
    }

    public async Task<T> Get()
    {
        return await _repository.Get();
    }

    public async Task Remove(T model)
    {
        await _repository.Remove(model);
    }
}
