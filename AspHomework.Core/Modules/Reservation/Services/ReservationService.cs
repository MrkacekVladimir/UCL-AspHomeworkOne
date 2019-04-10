using System;
using System.Collections.Generic;
using System.Linq;
using AspHomework.Core.Modules.Reservation.Models;
using AspHomework.Core.Modules.Reservation.Services.Interfaces;

namespace AspHomework.Core.Modules.Reservation.Services
{
    public class ReservationService: IReservationService
    {
        public List<ReservationDateTime> GetReservationDateTimes(DateTime from, DateTime until, IEnumerable<DateTime> unavailableDates = null)
        {                        
            if (until.Date != from.Date && until.Date.AddDays(-1) != from.Date)
            {
                return new List<ReservationDateTime>();
            }

            int openedHours = 0;
            //If room is opened for 24 hours
            if (until.Date.AddDays(-1) == from.Date)
            {
                openedHours = 24;
            }
            else
            {
                openedHours = until.Hour - from.Hour;    
            }                        

            List<ReservationDateTime> dates = new List<ReservationDateTime>();
            DateTime dateNow = DateTime.Now;
            for (int i = 0; i < openedHours; i++)
            {
                
                bool isAvailable = !unavailableDates.Any(x => x.Hour == from.Hour + i) && from.AddHours(i) > DateTime.Now;
                ReservationDateTime dateTime = new ReservationDateTime(from.AddHours(i), isAvailable);
                dates.Add(dateTime);
            }

            return dates;
        }
    }
}
