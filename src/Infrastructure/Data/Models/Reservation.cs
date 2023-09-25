using Domain.Entities.BookReservationAggregate;
using Infrastructure.Data.Models.Base;

namespace Infrastructure.Data.Models;

public class Reservation : BaseEntity
{
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }

    public ICollection<User> Users { get; set; }
    public ICollection<Book> Books { get; set; }
}

