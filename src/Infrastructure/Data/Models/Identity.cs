using Infrastructure.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models;

public class Identity: BaseEntity
{
    public int OtpCode { get; set; }
    public DateTime Expiration { get; set; }
    public decimal Token { get; set; }
    public short TokenStatus { get; set; }


    [ForeignKey(nameof(Id))]
    public User User { get; set; }
}
