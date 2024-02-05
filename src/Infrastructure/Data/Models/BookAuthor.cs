using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Reflection.Emit;

namespace Infrastructure.Data.Models;

public class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; }
    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; }
}

public class BookAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        // Configure primary key
        builder.HasKey(ba => new { ba.BookId, ba.AuthorId });

        // Configure foreign key relationships
        builder.HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        builder.HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);
    }
}