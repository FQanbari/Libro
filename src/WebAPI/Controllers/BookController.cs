using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Api;

namespace WebAPI.Controllers;

public class BookController : ApiBaseController
{
    private readonly IService<Book> _service;

    public BookController(IService<Book> service)
    {
        this._service = service;
    }

    /// <summary>
    /// Get All books
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of books</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var books = await _service.GetAll(cancellationToken);

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
        await _service.AddOrUpdate(book, cancellationToken);

        return Ok(book);
    }
}
