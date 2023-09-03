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
    public async Task AddOrUpdate(Book domain, CancellationToken cancellationToken)
    {
        Assert.NotNull(domain, nameof(domain));
        var model = new Data.Models.Book { Id = domain.Id.Value, Description = domain.Description, Name = domain.Name, ISBN = domain.ISBN, GenerId = domain.GenerId, Price = domain.Price, PublishDate = domain.PublishDate };
        if(domain.Id != 0)
            _dbContext.Books.Update(model);
        else
            await _dbContext.Books.AddAsync(model, cancellationToken).ConfigureAwait(false);

        await _dbContext.SaveChangesAsync(cancellationToken);

    }

    public async Task<Book> FindById(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Books.Include(x => x.Authors).Where(x => x.Id == id).Select(x => new Book(x.Name, x.Description, x.Authors.Select(a => new Author { Id = a.Id, Name = a.Name}).ToList(), x.GenerId, x.PublishDate, x.ISBN, x.Price,x.Id)).FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public async Task<IQueryable<Book>> GetAll(string searchby, string searchfor, string sortby, CancellationToken cancellationToken)
    {
        var ba = _dbContext.Books.Include(x => x.Authors).Select(x => new { x.Id, x.Name, x.Description, x.ISBN, x.Authors, x.PublishDate, x.GenerId, x.Price }).AsEnumerable();
        
        Expression<Func<Author, bool>> predicate = (author) => false;

        if (searchby == "gener" && searchfor != null)
        {            
            ba = ba.Where(x => x.GenerId == int.Parse(searchfor));
        }
        if (searchby == "homeTown" && searchfor != null)
        {
            ba = ba.Where(x => x.Authors.Any(a => a.HomeTown == int.Parse(searchfor)));
        }
        if (searchby == "price" && searchfor != null)
        {
            ba = ba.Where(x => x.Price == decimal.Parse(searchfor));
        }
        var result = ba.Select(x => new Book(x.Name, x.Description, x.Authors.Select(a => new Author { Id = a.Id, Name = a.Name }).ToList(), x.GenerId, x.PublishDate, x.ISBN, x.Price, x.Id));
       
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
}
