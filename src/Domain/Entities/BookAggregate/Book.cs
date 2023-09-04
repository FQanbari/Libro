using Domain.Entities.MemberAggregate;

namespace Domain.Entities.BookAggregate;

public class Book
{
    public Book(string name, string description, List<Author> authors, int generId, DateTime publishDate, int isbn, decimal price, int? id = null)
    {
        Name = name;
        Description = description;
        _authors = authors;
        GenerId = generId;
        PublishDate = publishDate;
        ISBN = isbn;
        Price = price;
        Id = id ?? 0;
    }
    public int? Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    private List<Author> _authors { get; set; }
    public IReadOnlyList<Author> Authors => _authors ?? (_authors = new List<Author>());
    public void AddAuthor(Author author)
    {
        if (!_authors.Any(x => x.Id == author.Id))
            throw new ArgumentException("Author exist.");

        _authors.Add(author);
    }
    public int GenerId { get; set; }
    public DateTime PublishDate { get; private set;}
    public int ISBN { get; private set;}
    public decimal Price { get; private set;}
    public void UpdateTitle(string newTitle)
    {
        // TODO: Allows updating the title of the book.
    }
    public void UpdateGenre(int newGenreId)
    {
        // TODO: Allows changing the genre of the book.
    }
    public void SetPrice(decimal newPrice)
    {
        // TODO: Sets a new price for the book.
    }
    public void AddAuthor(int authorId)
    {
        // TODO: Associates an author with the book.
    }
    public void RemoveAuthor(int authorId)
    {
        // TODO: Disassociates an author from the book.
    }
}
