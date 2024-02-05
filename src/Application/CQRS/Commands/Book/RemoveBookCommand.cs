using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Book;

public class RemoveBookCommand : IRequest
{
    public int Id { get; set; }
    public RemoveBookCommand(int id)
    {
        Id = id;
    }
}

public class RemoveBookHandler : IRequestHandler<RemoveBookCommand>
{
    private readonly IBookService _bookService;

    public RemoveBookHandler(IBookService bookService)
    {
        this._bookService = bookService;
    }
    public async Task Handle(RemoveBookCommand request, CancellationToken cancellationToken)
    {
        await _bookService.Remove(request.Id, cancellationToken);
    }
}
