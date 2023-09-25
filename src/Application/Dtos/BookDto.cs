using Infrastructure.Data.Models;

namespace Application.DTOs;

public class BookDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
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
public class MemberDto : BaseDto
{

}
