using Application.DTOs;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Book;

public class AddBookCommand : IRequest<BookDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int GenerId { get; set; }
    public int ISBN { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }

    public List<int> Authors { get; set; }
    public AddBookCommand(string name, string description, int generId, int ISBM, decimal price, DateTime publishDate, List<int> authors, int? id)
    {
        id = id ?? 0;
        Name = name;
        Description = description;
        GenerId = generId;
        ISBN = ISBM;
        Price = price;
        PublishDate = publishDate;
        Authors = authors;
    }
}

public class AddBookHandler : IRequestHandler<AddBookCommand, BookDto>
{
    private readonly IBookService _bookService;
    public AddBookHandler(IBookService bookService)
    {
        _bookService = bookService;
    }
    public async Task<BookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new BookDto { Id = request.Id, Description = request.Description, GenerId = request.GenerId, ISBN = request.ISBN, Name = request.Name, Price = request.Price, PublishDate = request.PublishDate, Authors = request.Authors.Select(x => new AuthorDto { Id = x }).ToList() };
        await _bookService.AddOrUpdate(book , cancellationToken);
        return book;
    }
}
