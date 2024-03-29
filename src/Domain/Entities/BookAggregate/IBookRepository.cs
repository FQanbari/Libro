﻿using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.BookAggregate;

public interface IBookRepository
{
    Task<IQueryable<Book>> GetAll(string searchby, string searchfor, string sortby, CancellationToken cancellationToken);
    Task<Book> GetById(int id, CancellationToken cancellationToken);
    Task Update(Book domain, CancellationToken cancellationToken);
    Task Add(Book domain, CancellationToken cancellationToken);
    Task Remove(Book domain, CancellationToken cancellationToken);
}
