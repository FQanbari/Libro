using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Extensions;
using MediatR;

namespace Application.CQRS.Queries.Book;

public class GetAllBookQueries : IRequest<List<BookDto>>
{
    public string SearchBy { get; set; }
    public string SearchFor { get; set; }
    public int? Page { get; set; }
    public string SortBy { get; set; }
    public GetAllBookQueries(string searchby = "", string searchfor = "", int? page = null, string sortby = "") 
    {
        SearchBy = searchby;
        SearchFor = searchfor;
        SortBy = sortby;
        Page = page;
    }
}

public class GetAllBookHandler : IRequestHandler<GetAllBookQueries, List<BookDto>>
{
    private readonly IBookService _bookService;

    public GetAllBookHandler(IBookService bookService)
    {
        _bookService = bookService;
    }
    public async Task<List<BookDto>> Handle(GetAllBookQueries request, CancellationToken cancellationToken)
    {
        var books = await _bookService.GetAll(request.SearchBy, request.SearchFor, request.SortBy, cancellationToken)
        .ToPaging(request.Page ?? 1, 5);

        return books.ToList();
    }
}
