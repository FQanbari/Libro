using Infrastructure.Data.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using Domain.Entities.BookAggregate;

namespace Infrastructure.Data.Models;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int GenerId { get; set; }
    public int ISBN { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }

    public Gener Gener { get; set; }

    public List<BookAuthor> BookAuthors { get; set; }
    public List<Author> Authors { get; set; }
}
