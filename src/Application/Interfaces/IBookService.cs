using Application.Dtos;

namespace Application.Interfaces;

public interface IBookService
{
    Task<BookDto> FindById(CancellationToken cancellationToken, params object[] ids);
    Task<IEnumerable<BookDto>> GetAll(CancellationToken cancellationToken);
    Task AddOrUpdate(BookDto entity, CancellationToken cancellationToken);
    Task Remove(int id, CancellationToken cancellationToken);
}
