using System;
using System.Collections.Generic;
using AspHomework.Core.Modules.Reservation.Models;

namespace AspHomework.Core.Modules.Reservation.Services.Interfaces
{
    public interface IReservationService
    {
        List<ReservationDateTime> GetReservationDateTimes(DateTime from, DateTime until,
            IEnumerable<DateTime> unavailableDates);
    }
}