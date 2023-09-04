namespace Domain.Entities.ReservationAggregate;

public class Reservation
{
    public int? Id { get; private set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public void CompleteReservation()
    {
        // TODO: Marks the reservation as completed when the book is collected.
    }
    public void IsReservationExpired()
    {
        // TODO: Checks if the reservation has expired.
    }
}
