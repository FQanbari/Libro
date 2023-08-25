﻿using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.BookAggregate;

public interface IBookRepository
{
    Task<Book> FindById(int id, CancellationToken cancellationToken);
    Task AddOrUpdate(Book domain, CancellationToken cancellationToken);
    Task Remove(Book domain, CancellationToken cancellationToken);
}
