namespace Domain.Entities.BookReservationAggregate;

public interface IBookReservationRepository
{
    Task<BookReservation> GetById(int reservationId); // TODO: Retrieves a reservation by its unique identifier.
    Task Add(BookReservation reservation); // TODO: Adds a new reservation to the repository.
    Task Update(BookReservation reservation); // TODO: Updates an existing reservation in the repository.
    Task<IEnumerable<BookReservation>> ExpireReservations();
}
