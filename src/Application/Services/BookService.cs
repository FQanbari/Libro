using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.BookAggregate;
using Infrastructure.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Application.Service;

public class BookService: IBookService
{
    private readonly IRepository<Book> _repository;
    public BookService(IRepository<Book> repository)
    {
        _repository = repository;
    }
    public async Task AddOrUpdate(BookDto entity, CancellationToken cancellationToken)
    {
        await _repository.AddOrUpdate(new Book(entity.Name, new List<Author> { new Author { Id = entity.Id} }, entity.GenerId, entity.PublishDate, entity.ISBN, entity.Price), cancellationToken);
    }

    public async Task<BookDto> FindById(CancellationToken cancellationToken, params object[] ids)
    {
        var result = await _repository.FindById(cancellationToken, ids);

        return new BookDto { Price = result.Price, Name = result.Name, ISBN = result.ISBN, GenerId = result.GenerId, Id = result.Id.Value, PublishDate = result.PublishDate, Authors = result.Authors.Select(x => new AuthorDto { Id = x.Id}).ToList() };
    }

    public async Task<IEnumerable<BookDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _repository.TableNoTracking.ToListAsync();

        return result.Select(x => new BookDto { Price = x.Price, Name = x.Name, ISBN = x.ISBN, GenerId = x.GenerId, Id = x.Id.Value, PublishDate = x.PublishDate, Authors = x.Authors.Select(a => new AuthorDto { Id = a.Id }).ToList() }).ToList();
    }

    public async Task Remove(BookDto entity, CancellationToken cancellationToken)
    {
        await _repository.Remove(new Book(entity.Name, new List<Author> { new Author { Id = entity.Id } }, entity.GenerId, entity.PublishDate, entity.ISBN, entity.Price), cancellationToken);
    }
}
