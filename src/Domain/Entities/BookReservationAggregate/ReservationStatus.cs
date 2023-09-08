namespace Domain.Entities.BookReservationAggregate;

public enum ReservationStatus
{
    Failure,
    Pending,
    Completed,
    NotFound,
    Expired
}
