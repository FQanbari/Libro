namespace Domain.Exceptions;

public class ReservationNotFoundException : Exception
{
    public ReservationNotFoundException(int reservationId)
        :base()
    {
        
    }
}
