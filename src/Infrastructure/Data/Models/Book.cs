using Infrastructure.Data.Models.Base;

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

    public List<Author> Authors { get; set; }
}
