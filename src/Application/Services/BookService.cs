﻿using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.BookAggregate;
using Author = Infrastructure.Data.Models.Author;
using Book = Domain.Entities.BookAggregate.Book;

namespace Application.Service;

public class BookService: IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IRepository<Author> _authorRepository;
    public BookService(IBookRepository bookRepository, IRepository<Author> authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }
    public async Task AddOrUpdate(BookDto entity, CancellationToken cancellationToken)
    {
        var author = _authorRepository.TableNoTracking.ToList().Where(x => entity.Authors.Any(y => y.Id == x.Id)).ToList();
        if (author == null)
            throw new Exception("There is no author");

        if (entity.Id != 0)
            await _bookRepository.Update(new Book(entity.Name, entity.Description, author.Select(x => new Domain.Entities.BookAggregate.Author (x.Id, x.Name, x.City?.Name, x.City?.Id)).ToList(), entity.GenerId, entity.PublishDate, entity.ISBN, entity.Price,entity.Id), cancellationToken);
        else
            await _bookRepository.Add(new Book(entity.Name, entity.Description, author.Select(x => new Domain.Entities.BookAggregate.Author(x.Id, x.Name, x.City?.Name, x.City?.Id)).ToList(), entity.GenerId, entity.PublishDate, entity.ISBN, entity.Price, entity.Id), cancellationToken);
    }

    public async Task<BookDto> FindById(CancellationToken cancellationToken, params object[] ids)
    {
        var result = await _bookRepository.GetById(1, cancellationToken);

        return new BookDto { Price = result.Price, Name = result.Title, ISBN = result.ISBN, GenerId = result.GenerId, Id = result.Id.Value, PublishDate = result.PublishDate, Authors = result.Authors.Select(x => new AuthorDto { Id = x.Id}).ToList() };
    }

    public async Task<IQueryable<BookDto>> GetAll(string searchby, string searchfor, string sortby, CancellationToken cancellationToken)
    {
        var result = await _bookRepository.GetAll(searchby, searchfor, sortby, cancellationToken);

        return result.Select(x => new BookDto { Price = x.Price, Description = x.Description, Name = x.Title, ISBN = x.ISBN, GenerId = x.GenerId, Id = x.Id.Value, PublishDate = x.PublishDate, Authors = x.Authors.Select(a => new AuthorDto { Id = a.Id, Name = a.Name, HomeTown = a.HomeTown }).ToList() });
    }

    public async Task Remove(int id, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetById(id, cancellationToken);
        if (book == null)
            throw new Exception("The book is not found");
        await _bookRepository.Remove(book, cancellationToken);
    }
}
