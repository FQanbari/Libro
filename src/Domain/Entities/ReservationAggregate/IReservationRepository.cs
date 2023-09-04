using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Domain.Entities.ReservationAggregate;

public interface IReservationRepository
{
    Task<Reservation> GetById(int reservationId); // TODO: Retrieves a reservation by its unique identifier.
    Task Add(Reservation reservation); // TODO: Adds a new reservation to the repository.
    Task Update(Reservation reservation); // TODO: Updates an existing reservation in the repository.
}
