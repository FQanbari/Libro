using Infrastructure.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public int HomeTown { get; set; }

    [ForeignKey(nameof(HomeTown))]
    public City City { get; set; }

    public List<BookAuthor> BookAuthors { get; set; }
    public List<Book> Books { get; set; }
}
