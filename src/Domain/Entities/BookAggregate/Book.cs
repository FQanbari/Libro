﻿namespace Domain.Entities.BookAggregate;

public class Book
{
    public Book(string name, List<Author> authors, int generId, DateTime publishDate, int isbn, decimal price)
    {
        Name = name;
        _authors = authors;
        GenerId = generId;
        PublishDate = publishDate;
        ISBN = isbn;
        Price = price;
    }
    public string Name { get; private set; }
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
}
