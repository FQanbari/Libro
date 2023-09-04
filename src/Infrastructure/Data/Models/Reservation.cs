using Domain.Entities.ReservationAggregate;
using Infrastructure.Data.Models.Base;

namespace Infrastructure.Data.Models;

public class Reservation : BaseEntity
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
}

