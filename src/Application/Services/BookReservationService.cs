using Application.DTOs;
using Application.Interfaces;
using Domain.Entities.BookAggregate;
using Domain.Entities.BookReservationAggregate;
using Domain.Entities.MemberAggregate;
using Domain.Exceptions;
using Infrastructure.Data.Models;

namespace Application.Services;

public class BookReservationService : IBookReservationService
{
    private readonly IBookReservationRepository _reservationRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMemberRepository _memberRepository;

    public BookReservationService(
        IBookReservationRepository reservationRepository,
        IBookRepository bookRepository,
        IMemberRepository memberRepository)
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
        _memberRepository = memberRepository;
    }

    public async Task<ReservationDto> MakeReservation(int memberId, int bookId, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetById(memberId);
        if (member == null)
        {
            throw new MemberNotFoundException(memberId);
        }

        if ((await _bookRepository.GetById(bookId, cancellationToken)) == null)
        {
            throw new BookNotFoundException(bookId);
        }

        member.MakeReservation(bookId);
       
        _reservationRepository.Add(new BookReservation(memberId, bookId, member.MembershipExpiryDate.Value, DateTime.UtcNow));
        return new ReservationDto();
    }

    public async Task CompleteReservation(int reservationId)
    {
        // Perform business logic for completing a reservation.
        var reservation = await _reservationRepository.GetById(reservationId);
        if (reservation == null)
            throw new ReservationNotFoundException(reservationId);

        reservation.CompleteReservation();
        _reservationRepository.Update(reservation);
    }

    public async Task<ReservationStatus> CheckReservationStatus(int reservationId)
    {
        var reservation = await _reservationRepository.GetById(reservationId);
        if (reservation == null)
        {
            return ReservationStatus.NotFound;
        }
        else if (reservation.ExpirationDate < DateTime.UtcNow)
        {
            return ReservationStatus.Expired;
        }
        else if (reservation.ReservationStatus == ReservationStatus.Completed)
        {
            return ReservationStatus.Completed;
        }
        else
        {
            return ReservationStatus.Pending;
        }
    }

    public async Task ExpireReservations()
    {
        // Perform business logic to automatically expire reservations.
        var expiredReservations = await _reservationRepository.ExpireReservations();
        foreach (var reservation in expiredReservations)
        {
            reservation.ReservationExpire();
            _reservationRepository.Update(reservation);
        }

        foreach (var reservation in expiredReservations)
        {
            // Handle expired reservations (e.g., notify the member)
        }
    }
}

