﻿using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Api;

namespace WebAPI.Controllers;

public class BookController : ApiBaseController
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        this._bookService = bookService;
    }

    /// <summary>
    /// Get All books
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of books</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(string name, string desc, int pageNo, int pageSize ,CancellationToken cancellationToken)
    {
        var books = await _bookService.GetAll(name, desc, pageNo, pageSize, cancellationToken);

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
        await _bookService.AddOrUpdate(book, cancellationToken);

        return Ok(book);
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
        await _bookService.AddOrUpdate(book, cancellationToken);

        return Ok(book);
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
        await _bookService.Remove(id, cancellationToken);

        return Ok();
    }
}