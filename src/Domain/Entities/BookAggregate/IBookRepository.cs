using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.BookAggregate;

public interface IBookRepository
{
    Task<List<Book>> GetAll(string name, string desc, CancellationToken cancellationToken, int pageNo = 1, int pageSize = 10);
    Task<Book> FindById(int id, CancellationToken cancellationToken);
    Task AddOrUpdate(Book domain, CancellationToken cancellationToken);
    Task Remove(Book domain, CancellationToken cancellationToken);
}
