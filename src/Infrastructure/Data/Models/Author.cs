using Infrastructure.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public int HomeTown { get; set; }

    [ForeignKey(nameof(HomeTown))]
    public City City { get; set; }
}
