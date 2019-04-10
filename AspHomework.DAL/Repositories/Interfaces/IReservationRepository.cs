using System;
using System.Collections.Generic;
using AspHomework.DAL.Entities;

namespace AspHomework.DAL.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation GetById(long id);
        Reservation Create(long roomId, long userId, DateTime dateFrom, DateTime dateTo, string note);
        IEnumerable<DateTime> GetUnavailableDates(long roomId, DateTime dateWhen);
        bool IsDateAvailable(long roomId, DateTime date);
        
    }
}
