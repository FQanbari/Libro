using Infrastructure.Data.Models.Base;

namespace Infrastructure.Data.Models;

public class User: BaseEntity
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    public ICollection<Identity> Identities { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
