namespace Domain.Entities.BookReservationAggregate;

public class BookReservation
{
    public BookReservation(int memberId, int bookId, DateTime expirationDate, DateTime reservationDate, int? id = null)
    {
        Id = id;
        MemberId = memberId;
        BookId = bookId;
        ExpirationDate = expirationDate;
        ReservationDate = reservationDate;
    }
    public int? Id { get; private set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime ReservationDate { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public void CompleteReservation()
    {
        // Implement logic to mark the reservation as completed.
        if (ReservationStatus == ReservationStatus.Pending)
        {
            ReservationStatus = ReservationStatus.Completed;
        }
        else
        {
            throw new Exception("Reservation is already completed.");
        }
    }

    public bool IsReservationExpired()
    {
        // Implement logic to check if the reservation has expired.
        return DateTime.UtcNow > ExpirationDate;
    }
    public void ReservationExpire()
    {
        if(IsReservationExpired()) ReservationStatus = ReservationStatus.Expired;
    }
}
