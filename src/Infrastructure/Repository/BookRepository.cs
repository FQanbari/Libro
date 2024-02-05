using Domain.Entities.BookAggregate;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Infrastructure.Data.Models.Base;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Author = Domain.Entities.BookAggregate.Author;
using Book = Domain.Entities.BookAggregate.Book;

namespace Infrastructure.Repository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }   

    public async Task<Book> GetById(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Books.Include(x => x.Authors).Where(x => x.Id == id).Select(x => new Book(x.Name, x.Description, x.Authors.Select(a => new Author(a.Id, a.Name, a.City.Name, a.City.Id)).ToList(), x.GenerId, x.PublishDate, x.ISBN, x.Price,x.Id)).FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public async Task<IQueryable<Book>> GetAll(string searchby, string searchfor, string sortby, CancellationToken cancellationToken)
    {
        var ba = _dbContext.Books.Include(x => x.BookAuthors).ThenInclude(x => x.Author).ThenInclude(x => x.City).Select(x => new { x.Id, x.Name, x.Description, x.ISBN, x.BookAuthors, x.PublishDate, x.GenerId, x.Price }).AsEnumerable();
        
        Expression<Func<Author, bool>> predicate = (author) => false;

        if (searchby == "gener" && searchfor != null)
        {            
            ba = ba.Where(x => x.GenerId == int.Parse(searchfor));
        }
        if (searchby == "homeTown" && searchfor != null)
        {
            ba = ba.Where(x => x.BookAuthors.Any(a => a.Author.HomeTown == int.Parse(searchfor)));
        }
        if (searchby == "price" && searchfor != null)
        {
            ba = ba.Where(x => x.Price == decimal.Parse(searchfor));
        }
        var result = ba.Select(x => new Book(x.Name, x.Description, x.BookAuthors.Select(a => new Author(a.Author.Id, a.Author.Name, a.Author.City.Name, a.Author.City.Id)).ToList(), x.GenerId, x.PublishDate, x.ISBN, x.Price, x.Id));
       
        switch (sortby)
        {
            case "price":
                result.OrderBy(x => x.Price).AsQueryable(); 
                break;
            case "priceDesc":
                result.OrderByDescending(x => x.Price).AsQueryable();
                break;
            default:
                break;
        }

        return result.AsQueryable();
    }

    public async Task Remove(Book domain, CancellationToken cancellationToken)
    {
        Assert.NotNull(domain, nameof(domain));
        var book = await _dbContext.Books.Where(x => x.Id == domain.Id).FirstOrDefaultAsync().ConfigureAwait(false);
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Book domain, CancellationToken cancellationToken)
    {
        Assert.NotNull(domain, nameof(domain));

        var model = new Data.Models.Book { Id = domain.Id.Value, Description = domain.Description, Name = domain.Title, ISBN = domain.ISBN, GenerId = domain.GenerId, Price = domain.Price, PublishDate = domain.PublishDate, BookAuthors = domain.Authors.Select(x => new BookAuthor { AuthorId = x.Id }).ToList() };
        
        var ba = await _dbContext.BookAuthor.AsNoTracking().Where(x => x.BookId ==  domain.Id).ToListAsync();
        if (ba.Count > 0)
            _dbContext.BookAuthor.RemoveRange(ba);

        _dbContext.Books.Update(model);
       await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task Add(Book domain, CancellationToken cancellationToken)
    {
        Assert.NotNull(domain, nameof(domain));
        var model = new Data.Models.Book { Id = domain.Id.Value, Description = domain.Description, Name = domain.Title, ISBN = domain.ISBN, GenerId = domain.GenerId, Price = domain.Price, PublishDate = domain.PublishDate, BookAuthors = domain.Authors.Select(x => new BookAuthor { AuthorId = x.Id}).ToList() };

        await _dbContext.Books.AddAsync(model, cancellationToken).ConfigureAwait(false);      
       await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}
