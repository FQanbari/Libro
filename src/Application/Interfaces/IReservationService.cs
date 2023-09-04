using Domain.Entities.MemberAggregate;
using System.Diagnostics;

namespace Application.Interfaces;
public interface IReservationService
{
    Task MakeReservation(int memberId, int bookId); // TODO: Initiates the reservation process.
    Task CompleteReservation(int reservationId); // TODO: Marks a reservation as completed.
    Task CheckReservationStatus(int reservationId); // TODO: Checks the status of a reservation.
    Task ExpireReservations(); // TODO: Automatically expires reservations that have passed their expiration dates
}
