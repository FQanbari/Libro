using Infrastructure.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models;

public class MemberShip : BaseEntity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public DateTime CreatOn { get; set; }
    public DateTime Expiration { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}

