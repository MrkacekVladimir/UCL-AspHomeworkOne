using System;
using System.Collections.Generic;
using System.Linq;
using AspHomework.DAL.Entities;
using AspHomework.DAL.Repositories.Interfaces;

namespace AspHomework.DAL.Repositories
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public Reservation GetById(long id)
        {
            return _context.Reservations.FirstOrDefault(x => x.Id == id);
        }

        public Reservation Create(long roomId, long userId, DateTime dateFrom, DateTime dateTo, string note)
        {
            Reservation reservation = new Reservation();
            reservation.RoomId = roomId;
            reservation.UserId = userId;
            reservation.ReservedFrom = dateFrom;
            reservation.ReservedTo = dateTo;
            reservation.Note = note;

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return reservation;
        }

        public IEnumerable<DateTime> GetUnavailableDates(long roomId, DateTime dateWhen)
        {
            return _context.Reservations.Where(x => x.RoomId == roomId && x.ReservedFrom.Day == dateWhen.Day)
                .Select(x => x.ReservedFrom)
                .ToList();
        }

        public bool IsDateAvailable(long roomId, DateTime date)
        {
            if (DateTime.Now > date)
            {
                return false;
            }
            
            return !_context.Reservations.Any(x => x.RoomId == roomId 
                                                   && x.ReservedFrom.Year == date.Year 
                                                   && x.ReservedFrom.Month == date.Month 
                                                   && x.ReservedFrom.Day == date.Day 
                                                   && x.ReservedFrom.Hour == date.Hour);
        }
    }
}
