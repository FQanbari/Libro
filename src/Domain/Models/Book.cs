namespace Infrastructure.Models;

public class Book
{
    public string Name { get; set; }
    
    public int GenerId { get; set; }
    public int ISBN { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }

    public Gener Gener { get; set; }

    public List<Author> Authors { get; set; }
}
