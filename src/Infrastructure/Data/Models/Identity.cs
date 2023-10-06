using Infrastructure.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models;

public class Identity : BaseEntity
{
    public string OtpCode { get; set; }
    public DateTime ExpirationOtp { get; set; }
    public DateTime? ExpirationToken { get; set; }
    public string? Token { get; set; }
    public short TokenStatus { get; set; }
    public DateTime CreatOn { get; set; }


    [ForeignKey(nameof(Id))]
    public User User { get; set; }
}
