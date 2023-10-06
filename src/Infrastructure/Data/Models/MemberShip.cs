using Infrastructure.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models;

public class MemberShip : BaseEntity
{
    public DateTime CreatOn { get; set; }
    public DateTime Expiration { get; set; }
    public short Type { get; set; }

    [ForeignKey(nameof(Id))]
    public User User { get; set; }
}

