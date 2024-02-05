using Infrastructure.Data.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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

    public int UserId { get; set; }

    // Navigation property
    public User User { get; set; }
}