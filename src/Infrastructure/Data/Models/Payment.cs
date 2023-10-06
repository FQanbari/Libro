using Infrastructure.Data.Models.Base;

namespace Infrastructure.Data.Models;

public class Payment : BaseEntity
{
    public Payment()
    {
        CreateOn = DateTime.Now;
    }
    public decimal Amount { get; set; }
    public DateTime CreateOn { get; set; }
    public int Count { get; set; }

}