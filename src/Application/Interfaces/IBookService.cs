using Application.DTOs;

namespace Application.Interfaces;

public interface IBookService
{
    Task<BookDto> FindById(CancellationToken cancellationToken, params object[] ids);
    Task<IQueryable<BookDto>> GetAll(string searchby, string searchfor, string sortby, CancellationToken cancellationToken);
    Task AddOrUpdate(BookDto entity, CancellationToken cancellationToken);
    Task Remove(int id, CancellationToken cancellationToken);
}
