using Infrastructure.Data.Models;

namespace Application.Dtos;

public class BookDto : BaseDto
{
    public string Name { get; set; }
    public int GenerId { get; set; }
    public int ISBN { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }

    public List<AuthorDto> Authors { get; set; }
}

public class AuthorDto : BaseDto
{
}

public class BaseDto
{
    public int Id { get; set; }
}