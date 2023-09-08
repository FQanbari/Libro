using Domain.Entities.MemberAggregate;

namespace Domain.Entities.BookAggregate;

public class Book
{
    public Book(string name, string description, List<Author> authors, int generId, DateTime publishDate, int isbn, decimal price, int? id = null)
    {
        Title = name;
        Description = description;
        _authors = authors;
        GenerId = generId;
        PublishDate = publishDate;
        ISBN = isbn;
        Price = price;
        Id = id ?? 0;
    }
    public int? Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    private List<Author> _authors { get; set; }
    public IReadOnlyList<Author> Authors => _authors ?? (_authors = new List<Author>());
    public int GenerId { get; set; }
    public DateTime PublishDate { get; private set;}
    public int ISBN { get; private set;}
    public decimal Price { get; private set;}
    public void UpdateTitle(string newTitle)
    {
        if (!string.IsNullOrWhiteSpace(newTitle))
        {
            Title = newTitle;
        }
    }

    public void UpdateGenre(int newGenre)
    {
        if (newGenre > 0)
        {
            GenerId = newGenre;
        }
    }

    public void SetPrice(decimal newPrice)
    {
        if (newPrice >= 0)
        {
            Price = newPrice;
        }
    }

    public void AddAuthor(Author author)
    {
        if (author != null && !Authors.Any(a => a.Id == author.Id))
        {
            _authors.Add(author);
        }
    }

    public void RemoveAuthor(Author author)
    {
        if (author != null)
        {
            _authors.Remove(author);
        }
    }
}
