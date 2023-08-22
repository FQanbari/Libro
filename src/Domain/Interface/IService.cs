﻿namespace Application.Interface;

public interface IService<T> where T : class
{
    Task<T> Get();
    Task AddOrUpdate(T model);
    Task Remove(T model);
}
