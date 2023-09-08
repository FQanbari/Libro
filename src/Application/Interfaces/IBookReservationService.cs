using Application.DTOs;
using Domain.Entities.BookReservationAggregate;
using Domain.Entities.MemberAggregate;
using System.Diagnostics;
using System.Threading;

namespace Application.Interfaces;
public interface IBookReservationService
{
    Task<ReservationDto> MakeReservation(int memberId, int bookId, CancellationToken cancellationToken); // TODO: Initiates the reservation process.
    Task CompleteReservation(int reservationId); // TODO: Marks a reservation as completed.
    Task<ReservationStatus> CheckReservationStatus(int reservationId); // TODO: Checks the status of a reservation.
    Task ExpireReservations(); // TODO: Automatically expires reservations that have passed their expiration dates
}
