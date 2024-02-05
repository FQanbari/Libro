using Application.CQRS.Commands.Book;
using Application.CQRS.Queries.Book;
using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Api;

namespace WebAPI.Controllers;

public class BookController : ApiBaseController
{
    private readonly IMediator _mediatR;
    private readonly IBookService _bookService;

    public BookController(IMediator mediatR, IBookService bookService)
    {
        _mediatR = mediatR;
        _bookService = bookService;
    }

    /// <summary>
    /// Get All books
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of books</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken, string searchby = "", string searchfor = "", int? page = null, string sortby = "")
    {
        var books = await _mediatR.Send(new GetAllBookQueries(searchby, searchfor, page ?? 1, sortby), cancellationToken);

        return Ok(books);
    }

    /// <summary>
    /// Add Book
    /// </summary>
    /// <param name="book"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Add(BookDto book, CancellationToken cancellationToken)
    {
        var model = await _mediatR.Send(new AddBookCommand(book.Name, book.Description, book.GenerId, book.ISBN, book.Price, book.PublishDate, book.Authors.Select(x => x.Id).ToList(), book.Id), cancellationToken);

        return Ok(model);
    }

    /// <summary>
    /// Update Book
    /// </summary>
    /// <param name="book"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update(BookDto book, CancellationToken cancellationToken)
    {
        var model = await _mediatR.Send(new UpdateBookCommand(book.Id, book.Name, book.Description, book.GenerId, book.ISBN, book.Price, book.PublishDate, book.Authors.Select(x => x.Id).ToList()), cancellationToken);

        return Ok(model);
    }
    /// <summary>
    /// Remove book
    /// </summary>
    /// <param name="id">bookId</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> Remove(int id, CancellationToken cancellationToken)
    {
        await _mediatR.Send(new RemoveBookCommand(id), cancellationToken);        

        return Ok();
    }
}
