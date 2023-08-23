using Infrastructure.Data.Models.Base;

namespace Infrastructure.Data.Models;

public class Author : BaseEntity
{
    public string Name { get; set; }
}
